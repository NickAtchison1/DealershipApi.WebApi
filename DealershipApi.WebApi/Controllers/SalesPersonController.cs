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

        public IHttpActionResult GetSalesPeople()
        {
            SalesPersonService s = CreateSalesPersonService();
            var salespeople = s.GetSalesPeople();
            return Ok(salespeople);
        }

        public IHttpActionResult CreateSalesPerson(SalesPersonCreate model)
        {

        }
    }
}
