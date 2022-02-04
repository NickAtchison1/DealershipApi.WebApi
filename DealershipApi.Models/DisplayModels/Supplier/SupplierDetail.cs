using DealershipApi.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Supplier
{
    public class SupplierDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SupplierType SupplierType { get; set; }
        public string Email { get; set; }
    }
}
