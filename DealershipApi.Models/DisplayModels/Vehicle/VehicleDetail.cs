using DealershipApi.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Vehicle
{
    public class VehicleDetail
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public decimal SalesPrice { get; set; }
        public int DealershipId { get; set; }
        public VehicleCondition VehicleCondition { get; set; }
        public double Mileage { get; set; }
    }
}
