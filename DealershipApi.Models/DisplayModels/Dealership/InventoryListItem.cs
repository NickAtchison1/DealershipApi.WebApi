using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Dealership
{
    public class InventoryListItem
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string DealershipLocation { get; set; }        
        public bool InStock { get; set; }

    }
}
