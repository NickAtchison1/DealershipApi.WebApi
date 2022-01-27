using DealershipApi.Models.DisplayModels.Supplier;
using DealershipApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealershipApi.WebApi.Controllers
{
    public class SupplierController : ApiController
    {
        //[Authorize]
        public class VehicleController : ApiController
        {
            private SupplierService CreateSupplierService()
            {
                return new SupplierService();
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
}
