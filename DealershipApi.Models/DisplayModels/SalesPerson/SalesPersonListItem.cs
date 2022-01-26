using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.SalesPerson
{
    public class SalesPersonListItem
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int SalesPersonId { get; set; }
        public int DealerShipId { get; set; }

    }
}
