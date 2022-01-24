using DealershipApi.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Transaction
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
        public TransactionType TypeOfTransaction { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string CustomerName { get; set; }
        public string SalesPersonName { get; set; }
        public string DealershipName { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
