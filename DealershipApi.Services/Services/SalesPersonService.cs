using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealershipApi.Models.DisplayModels.SalesPerson;
using DealershipApi.Data.DataModels;


namespace DealershipApi.Services.Services
{
    public class SalesPersonService
    {
        public SalesPersonService()
        {

        }

        public bool CreateSalesPerson (SalesPersonCreate model)
        {
            var entity = new SalesPerson()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SalesPeople.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SalesPersonListItem> GetSalesPeople()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.SalesPeople.Select(
                    s => new SalesPersonListItem
                    {
                        FullName = s.FirstName + " " + s.LastName,
                        Email = s.Email
                    });
                return query.ToArray();
            }
        }

        public SalesPersonDetail GetSalesPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SalesPeople
                        .Single(s => s.Id == id);

                return
                    new SalesPersonDetail
                    {
                        Id = entity.Id,
                        DealershipId = entity.DealerShipID,
                        FullName = entity.FirstName + " " + entity.LastName,
                        Email = entity.Email
                    };
            }
        }

        public bool UpdateSalesPerson(SalesPersonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SalesPeople
                        .Single(s => s.Id == model.Id);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;

                return ctx.SaveChanges() > 0;
            }
        }


        
    }
}
