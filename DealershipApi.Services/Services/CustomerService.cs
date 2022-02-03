
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
        
        private readonly string _userId;
        public CustomerService(string userId)
        {
            _userId = userId;
        }
        public bool CreateCustomer(CustomerCreate customer)
        {
            var entity = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Email = customer.Email,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Customers
                    .Select(d => new CustomerListItem()
                    {
                        CustomerId = d.Id,
                        FullName = d.FullName,
                        Address = d.Address,
                        Email = d.Email
                    });
                return query.ToList();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(d => d.Id == id);
                return new CustomerDetail
                {
                    CustomerId = entity.Id,
                    FullName = entity.FullName,
                    Address = entity.Address,
                    Email = entity.Email
                };
            }
        }

        public bool UpdateCustomer(CustomerEdit customer)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(d => d.Id == customer.CustomerId);

                entity.FirstName = customer.FirstName;
                entity.LastName = customer.LastName;
                entity.Address = customer.Address;
                entity.Email = customer.Email;
                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(d => d.Id == id);
                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
