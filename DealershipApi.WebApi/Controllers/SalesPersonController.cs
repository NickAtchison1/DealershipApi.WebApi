using DealershipApi.Models.DisplayModels.SalesPerson;
using DealershipApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealershipApi.WebApi.Controllers
{
    [Authorize]
    public class SalesPersonController : ApiController
    {


    
        private SalesPersonService CreateSalesPersonService()
        {
            return new SalesPersonService();
        }

        [HttpGet]
        public IHttpActionResult GetSalesPeople()
        {
            SalesPersonService s = CreateSalesPersonService();
            var salespeople = s.GetSalesPeople();
            return Ok(salespeople);
        }

        [HttpPost]
        public IHttpActionResult CreateSalesPerson(SalesPersonCreate person)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var salesperson = CreateSalesPersonService();

            if (!salesperson.CreateSalesPerson(person)) return InternalServerError();

            return Ok(salesperson);
        }

        [HttpPut]

        public IHttpActionResult UpdateSalesPerson(SalesPersonEdit person)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateSalesPersonService();

            if (!service.UpdateSalesPerson(person)) return InternalServerError();

            return Ok(person);
        }
    
        [HttpDelete]
        public IHttpActionResult DeleteSalesPerson(int id)
        {
            var service = CreateSalesPersonService();

            if (!service.RemoveSalesPerson(id)) return InternalServerError();

            return Ok("Sales person removed!");
        }

    }
}
