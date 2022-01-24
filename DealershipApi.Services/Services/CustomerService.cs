
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
        private readonly int _userId;

        public CustomerService(int userId)
        {
            _userId = userId;
        }

        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public bool CreateCustomer(CustomerCreate customer)
        {
            var entity = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Email = customer.Email,
            };

            _context.Customers.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Customers.Where(e => e.Id == _userId).Select(e => new CustomerListItem
                {
                    CustomerId = e.Id,
                    FirstName = e.FirstName,
                    Address = e.Address,
                    Email=e.Email,
                }
                 );
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.Id == id);
                return new CustomerDetail
                {
                    CustomerId = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Address = entity.Address,
                    Email = entity.Email,
                };
            }
        }

        public bool UpdateCustomer(CustomerEdit customer)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.Id == customer.CustomerId);

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
                var entity = ctx.Customers.Single(e => e.Id == id);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
