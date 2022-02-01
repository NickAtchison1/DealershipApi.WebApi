using DealershipApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealershipApi.WebApi.Controllers
{
    [Authorize(Roles = "Admin,Sales")]
    public class InventoryController : ApiController
    {
        private InventoryListItemService CreateInventoryListItemService()
        {
            var inventorylistitemservice = new InventoryListItemService();
            return inventorylistitemservice;
        }
        
        [HttpGet]
        [Route("api/Inventory/InStock")]
        public IHttpActionResult InStock()
        {
            InventoryListItemService iliservice = CreateInventoryListItemService();
            var listitem = iliservice.GetInventoryInStock();
            return Ok(listitem);
        }

        [HttpGet]
        [Route("api/Inventory/NotInStock")]
        public IHttpActionResult NotInStock()
        {
            InventoryListItemService iliservice = CreateInventoryListItemService();
            var listitem = iliservice.GetInventoryNotInStock();
            return Ok(listitem);
        }

        [HttpGet]
        [Route("api/Inventory/AllStock")]
        public IHttpActionResult AllInStock()
        {
            InventoryListItemService iliservice = CreateInventoryListItemService();
            var listitem = iliservice.GetInventoryAllAvailableStock();
            return Ok(listitem);
        }


    }
}
