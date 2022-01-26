using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Transaction;
using DealershipApi.Models.DisplayModels.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Services.Services
{
    public class TransactionService
    {
        public bool CreatePurchaseTransaction(VehicleCreate model, TransactionPurchaseCreate transaction)
        {
            var vehicleEntity  = new Vehicle()
            {
                Make = model.Make,
                Model = model.Model,
                ModelYear = model.ModelYear,
                Color = model.Color,
                InvoicePrice = model.SalesPrice,
                DealershipId = model.DealershipId,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vehicles.Add(vehicleEntity);
            }

            var entity = new Transaction()
            {
                TypeOfTransaction = transaction.TypeOfTransaction,
                VehicleId = vehicleEntity.Id,
                CustomerId = transaction.CustomerId,
                SalesPersonId = transaction.SalesPersonId,
                DealershipId = transaction.DealershipId,
                SalesPrice = transaction.SalesPrice,
                SalesDate = transaction.SalesDate
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateTransferTransaction(TransactionPurchaseCreate transfer)
        {
            using (var ctx = new ApplicationDbContext())
            {
                string Purchase = ((TransactionType)(2)).ToString();
                var transaction = new Transaction()
                {
                    TypeOfTransaction = TransactionType.Purchase,
                    VehicleId = transfer.VehicleId,
                    CustomerId = transfer.CustomerId,
                    SalesPersonId = transfer.SalesPersonId,
                    DealershipId = transfer.DealershipId,
                    SalesPrice = transfer.SalesPrice,
                    SalesDate = transfer.SalesDate
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
