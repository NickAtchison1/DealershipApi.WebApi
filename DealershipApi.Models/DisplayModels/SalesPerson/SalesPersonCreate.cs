using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealershipApi.Models.DisplayModels.SalesPerson
{
    public class SalesPersonCreate
    {             
        [Required]
        [MaxLength(128, ErrorMessage = "First names can only be 128 charachters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(128, ErrorMessage = "Last names can only be 128 charachters")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        public int DealerShipId { get; set; }

    }
}

