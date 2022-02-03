using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Dealership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Services.Services
{
    public class DealershipService
    {
        private readonly string _userId;
        public DealershipService(string userId)
        {
            _userId = userId;
        }
        public bool CreateDealership(DealershipCreate model)
        {
            var entity = new Dealership()
            {
                Name = model.Name,
                Address = model.Address
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dealerships.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DealershipListItem> GetDealerships()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Dealerships
                    .Select(d => new DealershipListItem()
                    {
                        DealershipId = d.Id,
                        DealershipName = d.Name,
                        Address = d.Address
                    });
                return query.ToList();
            }
        }

        public DealershipDetail GetDealershipById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Dealerships.Single(d => d.Id == id);
                return new DealershipDetail
                {
                    DealershipId = entity.Id,
                    DealershipName = entity.Name,
                    Address = entity.Address
                };
            }
        }

        public bool UpdateDealership(DealershipEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Dealerships.Single(d => d.Id == model.DealershipId);
                entity.Name = model.DealershipName;
                entity.Address = model.Address;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDealership(int dealershipId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Dealerships.Single(d => d.Id == dealershipId);
                ctx.Dealerships.Remove(entity);

                return ctx.SaveChanges() == 1;  
            }
        }
    }
}
