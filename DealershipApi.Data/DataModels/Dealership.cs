using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Data.DataModels
{
    public class Dealership
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<SalesPerson> SalesPersons { get; set;}
        public virtual ICollection<Vehicle> Vehicles { get;}
        public virtual ICollection<Transaction> Transactions { get;}
    }
}
