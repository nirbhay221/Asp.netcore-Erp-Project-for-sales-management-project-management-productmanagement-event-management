using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class AlternateEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Availability { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public string HomeAddress { get; set; }
        public string ReportsTo { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Dob { get; set; }
        public DateTime PassportDate { get; set; }

        public DateTime SalaryDate { get; set; }

        public DateTime MedicalInsuranceDate { get; set; }

        public DateTime EidaDate { get; set; }
        public string Objective { get; set; }
    }
}
