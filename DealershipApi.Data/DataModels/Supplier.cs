using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public SupplierType SupplierType { get; set; }
        public string Email { get; set; }
    }
}
