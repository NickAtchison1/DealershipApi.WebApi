using DealershipApi.Models.DisplayModels.Transaction;
using DealershipApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DealershipApi.WebApi.Controllers
{
   
    public class TransactionController : ApiController
    {
        public IHttpActionResult Get()
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransactions();
            return Ok(transaction);
        }

        public IHttpActionResult Post(TransactionCreate transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTransactionService();

            if (!service.CreateTransaction(transaction))
            {
                return InternalServerError();
            }

            return Ok();
        }

        private TransactionService CreateTransactionService()
        {

            var transactionService = new TransactionService();
            return transactionService;
        }

        public IHttpActionResult Get(int id)
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransactionById(id);
            return Ok(transaction);
        }

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
