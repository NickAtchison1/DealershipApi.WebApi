using DealershipApi.Models.DisplayModels.Customer;
using DealershipApi.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealershipApi.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult Get()
        {
            CustomerService customerService = CreateCustomerService();
            var customer = customerService.GetCustomers();
            return Ok(customer);
        }

        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCustomerService();

            if (!service.CreateCustomer(customer))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private CustomerService CreateCustomerService()
        {
            
            var customerService = new CustomerService();
            return customerService;
        }

        public IHttpActionResult Get(int id)
        {
            CustomerService customerService = CreateCustomerService();
            var customer = customerService.GetCustomerById(id);
            return Ok(customer);
        }

        public IHttpActionResult Put(CustomerEdit customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCustomerService();

            if (!service.UpdateCustomer(customer))
            {
                return InternalServerError();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCustomerService();

            if (!service.DeleteCustomer(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
