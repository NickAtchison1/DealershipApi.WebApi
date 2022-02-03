using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Vehicle;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Services.Services
{
    public class VehicleService
    {
        private readonly string _userId;

        public VehicleService(string userId)
        {
            _userId = userId;
        }

        public bool CreateVehicle(VehicleCreate model)
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


                var entity =
                    new Vehicle()
                    {
                        Make = model.Make,
                        Model = model.Model,
                        ModelYear = model.ModelYear,
                        Color = model.Color,
                        DealershipId = loggedInUser.listOfRoles.Contains("Admin") ? model.DealershipId : loggedInUser.DealershipId,
                        CreatedBy = loggedInUser.Id,
                        CreatedDate = DateTime.Now,
                        Mileage = model.Mileage,
                        VehicleCondition = model.VehicleCondition,
                        InStock = true,
                    };
                if (loggedInUser.DealershipId == entity.DealershipId || loggedInUser.listOfRoles.Contains("Admin"))
                {
                    ctx.Vehicles.Add(entity);
                }
                
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VehicleListItem> GetVehicles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vehicles
                        .Select(
                        v =>
                            new VehicleListItem
                            {
                                Id = v.Id,
                                VehicleCondition = v.VehicleCondition,
                                VehicleName = v.VehicleName
                            }
                        );
                return query.ToArray();
            }
        }

        public VehicleDetail GetVehicleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
              
               
                var entity =
                    ctx
                        .Vehicles
                        .Single(v => v.Id == id);
                
                    return
                        new VehicleDetail
                        {
                            Id = entity.Id,
                            Make = entity.Make,
                            Model = entity.Model,
                            ModelYear = entity.ModelYear,
                            Color = entity.Color,
                            SalesPrice = entity.InvoicePrice,
                            DealershipId = entity.DealershipId,
                            VehicleCondition = entity.VehicleCondition,
                            Mileage = entity.Mileage,
                        };
                return null;
            }
        }

        public bool UpdateVehicle(VehicleEdit model)
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
                var entity =
                    ctx
                        .Vehicles
                        .Single(v => v.Id == model.Id);
                if (loggedInUser.DealershipId == entity.DealershipId || loggedInUser.listOfRoles.Contains("Admin"))
                {
                    entity.Id = model.Id;
                    entity.Make = model.Make;
                    entity.Model = model.Model;
                    entity.ModelYear = model.ModelYear;
                    entity.Color = model.Color;
                    entity.InvoicePrice = model.SalesPrice;
                    entity.DealershipId = model.DealershipId;
                    entity.VehicleCondition = model.VehicleCondition;
                    entity.Mileage = model.Mileage;
                }
              

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveVehicle(int id)
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
                var entity =
                    ctx
                        .Vehicles
                        .Single(v => v.Id == id);
                if(loggedInUser.DealershipId == entity.DealershipId || loggedInUser.listOfRoles.Contains("Admin"))
                {
                    ctx.Vehicles.Remove(entity);
                }
                
                return ctx.SaveChanges() == 1;
            }
        }

        public List<VehicleSearchDetail> SearchVehicles(string car)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Vehicles
                    .Select(v => new VehicleSearchDetail
                    {
                        Id = v.Id,
                        VehicleName = v.VehicleName,
                        Color = v.Color,
                        InvoicePrice = v.InvoicePrice,
                        DealershipId = v.DealershipId

                    }).Where(v => v.VehicleName.ToLower().Contains(car.ToLower()));

                return query.ToList();

            }
        }
    }
}
