﻿using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Vehicle;
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
                var loggedInUser =
                        ctx
                            .Users
                            .Single(u => u.Id == _userId);
                

                var entity =
                    new Vehicle()
                    {
                        Make = model.Make,
                        Model = model.Model,
                        ModelYear = model.ModelYear,
                        Color = model.Color,
                        InvoicePrice = model.SalesPrice,
                        DealershipId = model.DealershipId,
                        CreatedBy = loggedInUser.Id,
                        CreatedDate = model.CreatedDate,
                        Mileage = model.Mileage,
                        VehicleCondition = model.VehicleCondition,
                        InStock = true,
                    };

                ctx.Vehicles.Add(entity);
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
            }
        }

        public bool UpdateVehicle(VehicleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(v => v.Id == model.Id);

                entity.Id = model.Id;
                entity.Make = model.Make;
                entity.Model = model.Model;
                entity.ModelYear = model.ModelYear;
                entity.Color = model.Color;
                entity.InvoicePrice = model.SalesPrice;
                entity.DealershipId = model.DealershipId;
                entity.VehicleCondition = model.VehicleCondition;
                entity.Mileage = model.Mileage;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveVehicle(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(v => v.Id == id);
                ctx.Vehicles.Remove(entity);
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
                        InvoicePrice = v.InvoicePrice

                    }).Where(v => v.VehicleName.ToLower().Contains(car.ToLower()));

                return query.ToList();

            }
        }
    }
}
