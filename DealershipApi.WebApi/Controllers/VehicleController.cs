using DealershipApi.Models.DisplayModels.Vehicle;
using DealershipApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealershipApi.WebApi.Controllers
{
    //[Authorize]
    public class VehicleController : ApiController
    {
        private VehicleService CreateVehicleService()
        {
            return new VehicleService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            VehicleService vehicleService = CreateVehicleService();
            var vehicle = vehicleService.GetVehicles();
            return Ok(vehicle);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            VehicleService vehicleService = CreateVehicleService();
            var vehicle = vehicleService.GetVehicleById(id);
            return Ok(vehicle);
        }

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
