﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealershipApi.Models.DisplayModels.SalesPerson
{
    public class SalesPersonDetail
    {
        public int Id { get; set; }
        public int DealershipId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
