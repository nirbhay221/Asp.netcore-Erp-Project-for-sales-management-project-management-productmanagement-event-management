using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class Timeline
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Objective{ get; set; }
        public string Event { get; set; }
        public string Email { get; set; }
        public string Project  { get; set; }
        public DateTime Deadline { get; set; }
    }
}
