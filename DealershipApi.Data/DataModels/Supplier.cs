using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Data.DataModels
{
    public enum SupplierType
    {
        Wholeseller = 1,
        Individual
    }
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public SupplierType SupplierType { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
