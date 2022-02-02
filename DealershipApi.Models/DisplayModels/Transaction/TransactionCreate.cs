using DealershipApi.Data.DataModels;
using DealershipApi.Models.DisplayModels.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Transaction
{
    public class TransactionCreate
    {
        public TransactionType TypeOfTransaction { get; set; }
       
        public int VehicleId { get; set; }
      
        public int SupplierId { get; set; }
        public int DealershipId { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime SalesDate { get; set; }

        public String CreatedBy { get; set; }

        public DateTime CreatedDate{ get; set; }
       
        public String UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
