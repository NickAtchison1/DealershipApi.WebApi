
using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Services.Services
{
    public class CustomerService
    {
        public bool CreateCustoer(CustomerCreate customer)
        {
            var entity = new Customer()
            {
                
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Email = customer.Email
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
