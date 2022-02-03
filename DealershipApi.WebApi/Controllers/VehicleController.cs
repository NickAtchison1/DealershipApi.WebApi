using DealershipApi.Models.DisplayModels.Vehicle;
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
    [Authorize(Roles = "Sales,Manager,Admin")]
    public class VehicleController : ApiController
    {
        private VehicleService CreateVehicleService()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            var vehicleservice = new VehicleService(userId);
            return vehicleservice;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            VehicleService vehicleService = CreateVehicleService();
            var vehicle = vehicleService.GetVehicles();
            return Ok(vehicle);
        }

        [HttpGet]
        [Route("api/vehicle/{id}")]
        public IHttpActionResult Get(int id)
        {
            VehicleService vehicleService = CreateVehicleService();
            var vehicle = vehicleService.GetVehicleById(id);
            return Ok(vehicle);
        }

        [HttpGet]
        [Route("api/vehicle/search/{word}")]
        public IHttpActionResult Search(string word)
        {
            VehicleService vehicleService = CreateVehicleService();
            var vehicle = vehicleService.SearchVehicles(word);
            return Ok(vehicle);
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        public IHttpActionResult Post(VehicleCreate vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateVehicleService();

            if (!service.CreateVehicle(vehicle))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPut]
        public IHttpActionResult Put(VehicleEdit vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateVehicleService();

            if (!service.UpdateVehicle(vehicle))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateVehicleService();

            if (!service.RemoveVehicle(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
