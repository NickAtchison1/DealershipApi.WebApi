using DealershipApi.Models.DisplayModels.Supplier;
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
    public class SupplierController : ApiController
    {
        private SupplierService CreateSupplierService()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            var supplierservice = new SupplierService(userId);
            return supplierservice;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            SupplierService supplierService = CreateSupplierService();
            var supplier = supplierService.GetSuppliers();
            return Ok(supplier);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            SupplierService supplierService = CreateSupplierService();
            var supplier = supplierService.GetSupplierById(id);
            return Ok(supplier);
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        public IHttpActionResult Post(SupplierCreate supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateSupplierService();

            if (!service.CreateSupplier(supplier))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPut]
        public IHttpActionResult Put(SupplierEdit supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateSupplierService();

            if (!service.UpdateSupplier(supplier))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSupplierService();

            if (!service.RemoveSupplier(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
