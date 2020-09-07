using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
   
        [Table("Jacket")]
        public class Jacket
        {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        }
    
}
