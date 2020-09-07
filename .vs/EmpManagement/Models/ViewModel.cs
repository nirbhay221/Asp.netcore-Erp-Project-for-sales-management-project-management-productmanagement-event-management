using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class ViewModel
    {
        public RentedFromClients rented { get; set; }
        public ProductClient ProductClient { get; set; }
       public AltProject project { get; set; }
        public Sales sales { get; set; }
        public Client client { get; set; }
        public ProductSales ProductSales { get; set; }
        public ProjectClient ProjectClient { get; set; }
        public RentedForProject RentedForProject { get; set; }

        public Coast Coast { get; set; }
        public CoastStatus CoastStatus { get; set; }
    }
}
