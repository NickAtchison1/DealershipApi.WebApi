using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Data.DataModels
{
    public class SalesPerson
    {
        private string _fullName; 
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [MaxLength(25)]
        public string Email { get; set; }

        [ForeignKey (nameof(Dealership))]
        public int DealerShipId { get; set; }
        public virtual Dealership Dealership { get; set; }
        public string FullName
        {
            get
            {
                _fullName = $"{FirstName} {LastName}";
                return _fullName;
            }
            set { _fullName = value; }
        }
    }
}
