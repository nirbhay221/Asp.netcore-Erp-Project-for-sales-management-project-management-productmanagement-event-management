using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
     public class ProjectProduct
    {
        public Guid ProjectId { set; get; }

        public Guid ProductId { set; get; }

        public Project Project { set; get; }

        public Product Product{ set; get; }

    }
}
