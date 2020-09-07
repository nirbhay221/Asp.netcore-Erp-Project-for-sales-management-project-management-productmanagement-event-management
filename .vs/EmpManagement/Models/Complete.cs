using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class Complete
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Owner { get; set; }
        public string Lead { get; set; }
        public int Budget { get; set; }
        public int Profit { get; set; }
    }
  
    public class UpNext
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Owner { get; set; }
        public string Lead { get; set; }

        public int Budget { get; set; }
        public int Profit { get; set; }
    }
    public class Behind
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Owner { get; set; }
        public string Lead { get; set; }

        public int Budget { get; set; }
        public int Profit { get; set; }
    }
    public class AtRisk
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Owner { get; set; }
        public string Lead { get; set; }

        public int Budget { get; set; }
        public int Profit { get; set; }
    }
    public class Blocked
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Owner { get; set; }
        public string Lead { get; set; }

        public int Budget { get; set; }
        public int Profit { get; set; }
    }
    public class AltProject
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Owner { get; set; }
        public string Lead { get; set; }

        public int Budget { get; set; }
        public int Profit { get; set; }
    }
    public class OnTrack
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Owner { get; set; }
        public string Lead { get; set; }

        public int Budget { get; set; }
        public int Profit { get; set; }
    }
}
