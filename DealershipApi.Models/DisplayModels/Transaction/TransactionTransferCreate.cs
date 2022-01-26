using DealershipApi.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Transaction
{
    public class TransactionTransferCreate
    {
        public TransactionType TypeOfTransaction
        {
            get { return TransactionType.Transfer; }
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
