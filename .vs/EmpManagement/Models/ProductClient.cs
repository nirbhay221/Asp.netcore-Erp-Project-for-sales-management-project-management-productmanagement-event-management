using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class ProductClient
    {
        public int Id { get; set; }
        public int RentedFromClients_Id { get; set; }
        public int Client_Id { get; set; }
        public int Price { get; set; }
    }
}
