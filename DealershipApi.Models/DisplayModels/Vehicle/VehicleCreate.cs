using DealershipApi.Data.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Vehicle
{
    public class VehicleCreate
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public decimal SalesPrice { get; set; }
        [Required]
        [ForeignKey(nameof(Dealership))]
        public int DealershipId { get; set; }
        public VehicleCondition VehicleCondition { get; set; }
        public int Mileage { get; set; }
        public DateTime CreatedDate { get; set; }

        
    }
}
