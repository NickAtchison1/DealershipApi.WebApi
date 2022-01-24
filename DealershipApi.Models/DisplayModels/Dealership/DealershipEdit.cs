using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.Dealership
{
    public class DealershipEdit
    {
        public int DealershipId { get; set; }
        public string DealershipName { get; set; }

        public string Address { get; set; }
    }
}
