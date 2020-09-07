using EmpManagement.Models;
using EmpManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Text;

namespace EmpManagement.Controllers
{

    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("home")]
    public class HomeController : Controller
    {

        public AppDbContext db;
        public HomeController(AppDbContext _db)
        {
            db = _db;
        }
      [Route("csv")]
        public IActionResult CSV()
        {

            var comlumHeadrs = new string[]
                {
                "Id",
                "Title",
                "Description",
                "StartDate",
                "EndDate",
                    "Budget",
                    "Profit",
                    "Location"


                };

            var employeeRecords = db.Event.Select(e => new
            {
                id = e.Id,
                title = e.Title,
                description = e.Description,
                startdate = e.StartDate,
                enddate = e.EndDate,
                budget = e.Budget,
                profit = e.Profit,
                location = e.Location

            }).ToList();

            // Build ///*******the file content
            var employeecsv = new StringBuilder();
            employeeRecords.ForEach(line =>
            {
                employeecsv.AppendLine(string.Join(",", line));
            });

            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", comlumHeadrs)}\r\n{employeecsv.ToString()}");
            return File(buffer, "text/csv", $"Event.csv");

        }
        [Route("excel")]
        public IActionResult Excel()
        {

            var comlumHeadrs = new string[]
            {

                "Id",
                "Title",
                "Description",
                "StartDate",
                "EndDate",
                    "Budget",
                    "Profit",
                    "Location"
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
                var employeeRecords = (db.Event.Select(e => new
                {
                    id = e.Id,
                    title = e.Title,
                    description = e.Description,
                    startdate = e.StartDate,
                    enddate = e.EndDate,
                    budget = e.Budget,
                    profit = e.Profit,
                    location = e.Location


                }).ToList());
                foreach (var employee in employeeRecords)
                {
                    worksheet.Cells["A" + j].Value = employee.id;
                    worksheet.Cells["B" + j].Value = employee.title;
                    worksheet.Cells["C" + j].Value = employee.description;
                    worksheet.Cells["D" + j].Value = employee.startdate;
                    worksheet.Cells["E" + j].Value = employee.enddate;
                    worksheet.Cells["F" + j].Value = employee.budget;
                    worksheet.Cells["G" + j].Value = employee.profit;
                    worksheet.Cells["H" + j].Value = employee.location;
                    j++;
                }
                result = package.GetAsByteArray();

                worksheet.Cells["E1"].Value = 1;
                worksheet.Cells["E2"].Value = 2;
                worksheet.Cells["E3"].Value = 3;




            }

            return File(result, "application/ms-excel", $"Event.xlsx");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
    } 
}
