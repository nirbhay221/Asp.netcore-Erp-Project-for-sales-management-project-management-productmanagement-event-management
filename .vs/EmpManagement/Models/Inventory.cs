using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Project { get; set; }
        public DateTime RentedFrom { get; set; }
        public DateTime RentedTo { get; set; }
    }

    public class NotInInventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Project { get; set; }
        public DateTime RentedFrom { get; set; }
        public DateTime RentedTo { get; set; }
    }

    public class RentedForProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Project { get; set; }
        public DateTime RentedFrom { get; set; }
        public DateTime RentedTo { get; set; }
    }

    public class RentedFromClients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Project { get; set; }
        public DateTime RentedFrom { get; set; }
        public DateTime RentedTo { get; set; }
    }
    public class AltProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Project { get; set; }
        public DateTime RentedFrom { get; set; }
        public DateTime RentedTo { get; set; }
    }
}
