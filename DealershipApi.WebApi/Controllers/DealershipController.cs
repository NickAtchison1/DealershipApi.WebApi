using DealershipApi.Models.DisplayModels.Dealership;
using DealershipApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealershipApi.WebApi.Controllers
{
    public class DealershipController : ApiController
    {
        private DealershipService CreateDealershipService()
        {
            return new DealershipService();
        }

        [HttpGet]
        public IHttpActionResult GetAllDealerships()
        {
            DealershipService dealershipService = CreateDealershipService();
            var dealerships = dealershipService.GetDealerships();
            return Ok(dealerships);
        }

        [HttpGet]
        public IHttpActionResult GetDealership(int id)
        {
            DealershipService dealershipService = CreateDealershipService();
            var dealership = dealershipService.GetDealershipById(id);
            return Ok(dealership);

        }
        [HttpPost]
        public IHttpActionResult CreateDealership(DealershipCreate dealership)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var dealershipService = CreateDealershipService();
            if(!dealershipService.CreateDealership(dealership)) return InternalServerError();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(DealershipEdit dealership)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var dealershipService = CreateDealershipService();
            if (!dealershipService.UpdateDealership(dealership)) return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var dealershipService = CreateDealershipService();
            if(!dealershipService.DeleteDealership(id)) return InternalServerError();
            return Ok();
        }

    }
}
