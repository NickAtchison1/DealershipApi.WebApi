using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Vehicle
{
    public class VehicleSearchDetail
    {
        public int Id { get; set; }
        public string VehicleName { get; set; }
        public string Color { get; set; }
        public decimal InvoicePrice { get; set; }

    }
}
