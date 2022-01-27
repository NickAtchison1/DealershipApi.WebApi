using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Transaction;
using DealershipApi.Models.DisplayModels.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Services.Services
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
    public class TransactionService
    {
        public void CreatePurchaseTransaction(TransactionCreate model)
        {
            var vehicleEntity = new Vehicle()
            {
                Make = model.Vehicle.Make,
                Model = model.Vehicle.Model,
                ModelYear = model.Vehicle.ModelYear,
                Color = model.Vehicle.Color,
                InvoicePrice = model.Vehicle.SalesPrice,
                DealershipId = model.Vehicle.DealershipId,
                InStock = true
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vehicles.Add(vehicleEntity);
                 ctx.SaveChanges();
            }

            using (var ctx = new ApplicationDbContext())
            {
                var newVehicle =
                    ctx
                        .Vehicles
                        .Single(v => v.Id == vehicleEntity.Id);
            

            var entity = new Transaction()
            {
                TypeOfTransaction = model.TypeOfTransaction,
                VehicleId = newVehicle.Id,
                CustomerId = model.CustomerId,
                SalesPersonId = model.SalesPersonId,
                DealershipId = newVehicle.DealershipId,
                SalesPrice = newVehicle.InvoicePrice,
                SalesDate = model.SalesDate
            };

           
                ctx.Transactions.Add(entity);
                 ctx.SaveChanges();
            }
        }

        public bool CreateTransferTransaction(TransactionPurchaseCreate transfer)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var transaction = new Transaction()
                {
                    TypeOfTransaction = TransactionType.Transfer,
                    VehicleId = transfer.VehicleId,
                    CustomerId = transfer.CustomerId,
                    SalesPersonId = transfer.SalesPersonId,
                    DealershipId = transfer.DealershipId,
                    SalesPrice = 0,
                    SalesDate = DateTime.Today
                };

                ctx.Transactions.Add(transaction);

                var entity =
                    ctx
                        .Vehicles
                        .Single(v => v.Id == transfer.VehicleId);

                entity.Id = transfer.VehicleId;
                entity.DealershipId = transfer.DealershipId;
                return ctx.SaveChanges() > 0;
            }
        }

        public bool CreateSaleTransaction(TransactionPurchaseCreate sale)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var transaction = new Transaction()
                {
                    TypeOfTransaction = TransactionType.Sale,
                    VehicleId = sale.VehicleId,
                    CustomerId = sale.CustomerId,
                    SalesPersonId = sale.SalesPersonId,
                    DealershipId = sale.DealershipId,
                    SalesPrice = sale.SalesPrice,
                    SalesDate = sale.SalesDate
                };

                ctx.Transactions.Add(transaction);

                var entity =
                    ctx
                        .Vehicles
                        .Single(v => v.Id == sale.VehicleId);

                entity.Id = sale.VehicleId;
                entity.InStock = false;
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Transactions
                    .Select(d => new TransactionListItem()
                    {
                        TypeOfTransaction = d.TypeOfTransaction,
                        VehicleName = d.Vehicle.VehicleName,
                        SalesPersonName = d.SalesPerson.FullName,
                        DealershipName = d.Dealership.Name,
                        SalesPrice = d.SalesPrice,
                        SalesDate = d.SalesDate
                    });
                return query.ToList();
            }
        }

        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Single(d => d.Id == id);
                return new TransactionDetail
                {
                    TransactionId = entity.Id,
                    TypeOfTransaction = entity.TypeOfTransaction,
                    VehicleId = entity.VehicleId,
                    VehicleName = entity.Vehicle.VehicleName,
                    CustomerName = entity.Customer.FullName,
                    SalesPersonName = entity.SalesPerson.FullName,
                    DealershipName = entity.Dealership.Name,
                    SalesPrice = entity.SalesPrice,
                    SalesDate = entity.SalesDate
                };
            }
        }

        public bool UpdateTransaction(TransactionEdit transaction)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Single(d => d.Id == transaction.Id);

                entity.Id = transaction.Id;
                entity.VehicleId = transaction.VehicleId;
                entity.CustomerId = transaction.CustomerId;
                entity.SalesPersonId = transaction.SalesPersonId;
                entity.DealershipId = transaction.DealershipId;
                entity.SalesPrice = transaction.SalesPrice;
                entity.SalesDate = transaction.SalesDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Transactions.Single(d => d.Id == id);
                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
