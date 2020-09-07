using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rep { get; set; }

        public string SalesStage { get; set; }
        public string Priority { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public int ForeCastValue { get; set; }

        public int Probability{ get; set; }
        public DateTime LastContact{ get; set; }
        public int SignedContractValue{ get; set; }
        public int Quantity { get; set; }

        public string Notes { get; set; }
    }
    public class Evaluation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rep { get; set; }

        public string SalesStage { get; set; }
        public string Priority { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public int ForeCastValue { get; set; }

        public int Probability { get; set; }
        public DateTime LastContact { get; set; }
        public int SignedContractValue { get; set; }

        public string Notes { get; set; }
    }
    public class Negotiation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rep { get; set; }

        public string SalesStage { get; set; }
        public string Priority { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public int ForeCastValue { get; set; }

        public int Probability { get; set; }
        public DateTime LastContact { get; set; }
        public int SignedContractValue { get; set; }

        public string Notes { get; set; }
    }
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rep { get; set; }

        public string SalesStage { get; set; }
        public string Priority { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public int ForeCastValue { get; set; }

        public int Probability { get; set; }
        public DateTime LastContact { get; set; }
        public int SignedContractValue { get; set; }

        public string Notes { get; set; }
    }
    public class ClosedWon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rep { get; set; }

        public string SalesStage { get; set; }
        public string Priority { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public int ForeCastValue { get; set; }

        public int Probability { get; set; }
        public DateTime LastContact { get; set; }
        public int SignedContractValue { get; set; }

        public string Notes { get; set; }
    }
    public class ClosedLost
    {public int Id { get; set; }
        public string Name { get; set; }
        public string Rep { get; set; }

        public string SalesStage { get; set; }
        public string Priority { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public int ForeCastValue { get; set; }

        public int Probability { get; set; }
        public DateTime LastContact { get; set; }
        public int SignedContractValue { get; set; }

        public string Notes { get; set; }
    }
}
