using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace EmpManagement.Controllers
{[Route("excelexportsales")]
    public class ExcelExportSalesController : Controller
    {
        public AppDbContext db;
        public ExcelExportSalesController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("csv")]
        public IActionResult CSV()
        {

            var comlumHeadrs = new string[]
                {
                "Id",
                "Name",
                "Rep",
                "SalesStage",
                "Priority",
                    "ExpectedCloseDate",
                   "ForeCastValue",
                    "Probability",
                    "LastContact",
                    "SignedContractValue",
                    "Quantity",
                    "Notes"
                };

            var employeeRecords = db.Sales.Select(e => new
            {
                id = e.Id,
                name = e.Name,
                rep = e.Rep,
               salesstage = e.SalesStage,
                priority = e.Priority,
                expectedclosedate = e.ExpectedCloseDate,
                forecastvalue = e.ForeCastValue,
                probability = e.Probability,
                lastcontact = e.LastContact,
                signedcontractvalue = e.SignedContractValue,
                quantity = e.Quantity,
                notes = e.Notes
            }).ToList();

            // Build ///*******the file content
            var employeecsv = new StringBuilder();
            employeeRecords.ForEach(line =>
            {
                employeecsv.AppendLine(string.Join(",", line));
            });

            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", comlumHeadrs)}\r\n{employeecsv.ToString()}");
            return File(buffer, "text/csv", $"Sales.csv");

        }
        [Route("excel")]
        public IActionResult Excel()
        {

            var comlumHeadrs = new string[]
            {

                "Id",
                "Name",
                "Rep",
                "SalesStage",
                "Priority",
                    "ExpectedCloseDate",
                   "ForeCastValue",
                    "Probability",
                    "LastContact",
                    "SignedContractValue",
                    "Quantity",
                    "Notes"
};

            byte[] result;

            using (var package = new ExcelPackage())
            {
                // add a new worksheet to the empty workbook

                var worksheet = package.Workbook.Worksheets.Add("Current Employee"); //Worksheet name
                using (var cells = worksheet.Cells[1, 1, 1, 11]) //(1,1) (1,5)
                {
                    cells.Style.Font.Bold = true;
                }

                //First add the headers
                for (var i = 0; i < comlumHeadrs.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].Value = comlumHeadrs[i];
                }

                //Add values
                var j = 2;
                var employeeRecords = (db.Sales.Select(e => new
                {

                    id = e.Id,
                    name = e.Name,
                    rep = e.Rep,
                    salesstage = e.SalesStage,
                    priority = e.Priority,
                    expectedclosedate = e.ExpectedCloseDate,
                    forecastvalue = e.ForeCastValue,
                    probability = e.Probability,
                    lastcontact = e.LastContact,
                    signedcontractvalue = e.SignedContractValue,
                    quantity = e.Quantity,
                    notes = e.Notes

                }).ToList());
                foreach (var employee in employeeRecords)
                {
                    worksheet.Cells["A" + j].Value = employee.id;
                    worksheet.Cells["B" + j].Value = employee.name;
                    worksheet.Cells["C" + j].Value = employee.rep;
                    worksheet.Cells["D" + j].Value = employee.salesstage;
                    worksheet.Cells["E" + j].Value = employee.priority;
                    worksheet.Cells["F" + j].Value = employee.expectedclosedate;
                    worksheet.Cells["G" + j].Value = employee.forecastvalue;
                    worksheet.Cells["H" + j].Value = employee.probability;
                    worksheet.Cells["I" + j].Value = employee.lastcontact;
                    worksheet.Cells["J" + j].Value = employee.signedcontractvalue;
                    worksheet.Cells["K" + j].Value = employee.quantity;
                    worksheet.Cells["L" + j].Value = employee.notes;
                    j++;
                }
                result = package.GetAsByteArray();

                worksheet.Cells["E1"].Value = 1;
                worksheet.Cells["E2"].Value = 2;
                worksheet.Cells["E3"].Value = 3;




            }

            return File(result, "application/ms-excel", $"Sales.xlsx");
        }

    }
}