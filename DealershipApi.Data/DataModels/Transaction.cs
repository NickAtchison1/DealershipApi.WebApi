using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Data.DataModels
{
    public enum TransactionType
    {
        [Display(Name = "Sale")]
        Sale = 1,
        [Display(Name = "Purchase")]
        Purchase,
        [Display(Name = "Transfer")]
        Transfer
    }
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int? CustomerId { get; set; }
        public int? SalesPersonId { get; set; }
        public int DealershipId { get; set; }
        public int? SupplierId { get; set; }
        public decimal SalesPrice { get; set; }
        public DateTime SalesDate { get; set; }
        public TransactionType TypeOfTransaction { get; set; }

       
        public string CreatedBy { get; set; }
        
        public DateTime CreatedDate { get; set; }
      
        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
      
        public virtual Vehicle Vehicle { get; set; }
        public virtual Customer Customer { get; set; }  
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual Dealership Dealership { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
