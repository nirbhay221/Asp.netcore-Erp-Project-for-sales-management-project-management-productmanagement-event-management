using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class Item
    {
        public RentedForProject rented { get; set; }
        public int Quantity { get; set; }
    }
}
