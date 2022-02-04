using DealershipApi.Models.DisplayModels.Transaction;
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
    public class TransactionController : ApiController
    {
        private TransactionService CreateTransactionService()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            var transactionService = new TransactionService(userId);
            return transactionService;
        }

        public IHttpActionResult Get()
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransactions();
            return Ok(transaction);
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        [Route("api/Transaction/UsedPurchase/{vehicleId:int}")]
        public IHttpActionResult UsedPurchase(TransactionPurchaseCreate transaction, int vehicleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();
            service.CreateUsedVehiclePurchaseTransaction(transaction, vehicleId);

            return Ok("Purchase Complete");
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        [Route("api/Transaction/NewPurchase/{vehicleId:int}")]
        public IHttpActionResult NewPurchase(TransactionPurchaseCreate transaction, int vehicleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();
            service.CreateNewVehiclePurchaseTransaction(transaction, vehicleId);



            return Ok("Purchase Complete");
        }

        public IHttpActionResult Get(int id)
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransactionById(id);
            return Ok(transaction);
        }

        [Authorize(Roles = "Manager,Admin")]
        public IHttpActionResult Put(TransactionEdit transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();

            if (!service.UpdateTransaction(transaction))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Manager,Admin")]
        [Route("api/Transaction/Transfer")]
        public IHttpActionResult Transfer([FromBody] TransactionTransferCreate transactionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();

            if (!service.CreateTransferTransaction(transactionId))
            {
                return InternalServerError();
            }

            return Ok();
        }
        [HttpPost]
        [Authorize(Roles = "Manager,Admin")]
        [Route("api/Transaction/Sale")]
        public IHttpActionResult Sale(TransactionSaleCreate sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();

            if (!service.CreateSaleTransaction(sale))
            {
                return InternalServerError();
            }

            return Ok("Good sale!");
        }

        [Authorize(Roles = "Manager,Admin")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateTransactionService();

            if (!service.DeleteTransaction(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
