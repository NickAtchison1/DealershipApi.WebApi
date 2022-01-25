using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Transaction
{
    public class TransactionPurchaseCreate
    {
        public TransactionType TypeOfTransaction
        {
            get { return TransactionType.Purchase; }
        }
        public int VehicleId { get; set; }
    //   public VehicleCreate vehicleCreate { get; set; }
        public int CustomerId { get; set; }
        public int SalesPersonId { get; set; }
        public int DealershipId { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
