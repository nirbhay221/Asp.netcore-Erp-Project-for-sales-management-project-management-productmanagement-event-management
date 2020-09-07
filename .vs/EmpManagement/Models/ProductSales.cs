using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class ProductSales
    {
        public int Id { get; set; }
        public int Project_Id{ get; set; }
        public int Sales_Id { get; set; }
        public int Price { get; set; }
    }
}
