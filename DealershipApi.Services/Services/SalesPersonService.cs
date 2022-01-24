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



    }
}
