using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Transaction;
using DealershipApi.Models.DisplayModels.Vehicle;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Services.Services
{
    public class TransactionService
    {
        private readonly string _userId;
        public TransactionService(string userId)
        {
            _userId = userId;
        }
        public void CreateUsedVehiclePurchaseTransaction(TransactionPurchaseCreate model, int vehicleId)
        {


            using (var ctx = new ApplicationDbContext())
            {
                var loggedInUser = (from u in ctx.Users
                                    let query = (from ur in ctx.Set<IdentityUserRole>()
                                                 where ur.UserId.Equals(u.Id)
                                                 join r in ctx.Roles on ur.RoleId equals r.Id
                                                 select r.Name)
                                    where u.Id == _userId
                                    select new { u.Id, u.DealershipId, listOfRoles = query.ToList() }).Single();

                var vehicleToPurchase = ctx.Vehicles.Single(v => v.Id == vehicleId && v.VehicleCondition == VehicleCondition.Used);


                var entity = new Transaction()
                {
                    TypeOfTransaction = TransactionType.Purchase,
                    VehicleId = vehicleToPurchase.Id,
                    SupplierId = model.SupplierId,
                    DealershipId = vehicleToPurchase.DealershipId,
                    SalesPrice = vehicleToPurchase.InvoicePrice,
                    SalesDate = DateTime.Now,
                    CreatedBy = loggedInUser.Id,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = loggedInUser.Id,


                };

                if (loggedInUser.DealershipId == entity.DealershipId || loggedInUser.listOfRoles.Contains("Admin"))
                {
                    ctx.Transactions.Add(entity);
                }

                ctx.SaveChanges();


            }
        }

        public void CreateNewVehiclePurchaseTransaction(TransactionPurchaseCreate model, int vehicleId)
        {



            using (var ctx = new ApplicationDbContext())
            {
                var loggedInUser = (from u in ctx.Users
                                    let query = (from ur in ctx.Set<IdentityUserRole>()
                                                 where ur.UserId.Equals(u.Id)
                                                 join r in ctx.Roles on ur.RoleId equals r.Id
                                                 select r.Name)
                                    where u.Id == _userId
                                    select new { u.Id, u.DealershipId, listOfRoles = query.ToList() }).Single();

                var vehicleToPurchase = ctx.Vehicles.Single(v => v.Id == vehicleId && v.VehicleCondition == VehicleCondition.New);



                var entity = new Transaction()
                {
                    TypeOfTransaction = TransactionType.Purchase,
                    VehicleId = vehicleToPurchase.Id,
                    SupplierId = model.SupplierId,
                    DealershipId = vehicleToPurchase.DealershipId,
                    SalesPrice = vehicleToPurchase.InvoicePrice,
                    SalesDate = DateTime.Now,
                    CreatedBy = loggedInUser.Id,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = loggedInUser.Id,
                };

                if (loggedInUser.DealershipId == entity.DealershipId || loggedInUser.listOfRoles.Contains("Admin"))
                {
                    ctx.Transactions.Add(entity);
                }

                ctx.SaveChanges();
            }
        }

        public bool CreateTransferTransaction(TransactionTransferCreate transfer)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var loggedInUser = (from u in ctx.Users
                                    let query = (from ur in ctx.Set<IdentityUserRole>()
                                                 where ur.UserId.Equals(u.Id)
                                                 join r in ctx.Roles on ur.RoleId equals r.Id
                                                 select r.Name)
                                    where u.Id == _userId
                                    select new { u.Id, u.DealershipId, listOfRoles = query.ToList() }).Single();

                var transaction = new Transaction()
                {
                    TypeOfTransaction = TransactionType.Transfer,
                    VehicleId = transfer.VehicleId,
                    CustomerId = loggedInUser.listOfRoles.Contains("Admin") ? transfer.TransferDealershipId : loggedInUser.DealershipId,
                    DealershipId = transfer.SourceDealershipId,
                    SalesPrice = 0,
                    SalesDate = DateTime.Now,
                    CreatedBy = loggedInUser.Id,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = loggedInUser.Id,
                    UpdatedDate = DateTime.Now,
                };
                if ((loggedInUser.DealershipId == transaction.CustomerId || loggedInUser.listOfRoles.Contains("Admin")) && transaction.CustomerId != transaction.DealershipId)
                {
                    ctx.Transactions.Add(transaction);
                }



                var entity =
                    ctx
                        .Vehicles
                        .Single(v => v.Id == transfer.VehicleId);

                entity.Id = transfer.VehicleId;
                entity.DealershipId = transfer.TransferDealershipId;
                return ctx.SaveChanges() > 0;
            }
        }

        public bool CreateSaleTransaction(TransactionSaleCreate sale)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var loggedInUser = (from u in ctx.Users
                                    let query = (from ur in ctx.Set<IdentityUserRole>()
                                                 where ur.UserId.Equals(u.Id)
                                                 join r in ctx.Roles on ur.RoleId equals r.Id
                                                 select r.Name)
                                    where u.Id == _userId
                                    select new { u.Id, u.DealershipId, listOfRoles = query.ToList() }).Single();

                var transaction = new Transaction()
                {
                    TypeOfTransaction = TransactionType.Sale,
                    VehicleId = sale.VehicleId,
                    CustomerId = sale.CustomerId,
                    SalesPersonId = sale.SalesPersonId,
                    DealershipId = sale.DealershipId,
                    SalesPrice = sale.SalesPrice,
                    SalesDate = sale.SalesDate,
                    CreatedBy = loggedInUser.Id,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = loggedInUser.Id,
                    UpdatedDate = DateTime.Now,

                };

                if (loggedInUser.DealershipId == transaction.DealershipId || loggedInUser.listOfRoles.Contains("Admin"))
                

                    ctx.Transactions.Add(transaction);
                
                ctx.SaveChanges();
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
                var loggedInUser = (from u in ctx.Users
                                    let query = (from ur in ctx.Set<IdentityUserRole>()
                                                 where ur.UserId.Equals(u.Id)
                                                 join r in ctx.Roles on ur.RoleId equals r.Id
                                                 select r.Name)
                                    where u.Id == _userId

                                    select new { u.Id, u.DealershipId, listOfRoles = query.ToList() }).Single();



                var entity = (from t in ctx.Transactions
                              where t.Id == transaction.Id
                              where t.DealershipId == (loggedInUser.listOfRoles.Contains("Admin") ? transaction.DealershipId : loggedInUser.DealershipId)
                              select t).Single();

                entity.Id = transaction.Id;
                entity.VehicleId = transaction.VehicleId;
                entity.CustomerId = transaction.CustomerId;
                entity.SalesPersonId = transaction.SalesPersonId;
                entity.DealershipId = transaction.DealershipId;
                entity.SalesPrice = transaction.SalesPrice;
                entity.SalesDate = transaction.SalesDate;
                entity.CreatedBy = transaction.CreatedBy;
                entity.CreatedDate = transaction.CreatedDate;
                entity.UpdatedBy = loggedInUser.Id;
                entity.UpdatedDate = DateTime.Now;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var loggedInUser = (from u in ctx.Users
                                    let query = (from ur in ctx.Set<IdentityUserRole>()
                                                 where ur.UserId.Equals(u.Id)
                                                 join r in ctx.Roles on ur.RoleId equals r.Id
                                                 select r.Name)
                                    where u.Id == _userId

                                    select new { u.Id, u.DealershipId, listOfRoles = query.ToList() }).Single();
                var entity = ctx.Transactions.Single(d => d.Id == id);

                if (loggedInUser.DealershipId == entity.DealershipId || loggedInUser.listOfRoles.Contains("Admin"))
                {
                    ctx.Transactions.Remove(entity);
                }

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
