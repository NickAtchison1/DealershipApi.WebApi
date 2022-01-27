using DealershipApi.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Transaction
{
    public class TransactionListItem
    {
        public string TypeOfTransaction { get; set; }
        public string VehicleName { get; set; }
        public string SalesPersonName { get; set; }
        public string DealershipName { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
