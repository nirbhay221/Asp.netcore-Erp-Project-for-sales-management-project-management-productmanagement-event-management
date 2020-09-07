using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class Project
    {
        [Key]
        public Guid Id { set; get; }

        public string Name { set; get; }

        public ICollection<ProjectProduct> Products { set; get; }

        [NotMapped]
        public Dictionary<string, bool> UsedProducts { set; get; }

    }
}
