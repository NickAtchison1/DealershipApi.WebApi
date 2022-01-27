using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Data.DataModels
{
    public class Dealership
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(35)]
        public string Address { get; set; }

        public virtual ICollection<SalesPerson> SalesPersons { get; set;}
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Transaction> Transactions { get;}
    }
}
