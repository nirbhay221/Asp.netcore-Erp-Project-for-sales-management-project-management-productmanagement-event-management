using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace EmpManagement.Controllers
{[Route("excelexportemployee")]
    public class ExcelExportEmployeeController : Controller
    {
        public AppDbContext db;
        public ExcelExportEmployeeController(AppDbContext _db)
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
                "Location",
                "Availability",
                "Role",
                    "Status",
                    "StartDate",
                    "HomeAddress",
                    "ReportsTo",
                    "EmailAddress",
                    "Dob",
                    "PassportDate",
                    "SalaryDate",
                    "MedicalInsuranceDate",
                    "EidaDate",


                    "Objective"

                };

            var employeeRecords = db.AlternateEmployee.Select(e => new
            {
                id = e.Id,
                name = e.Name,
                location = e.Location,
                availability = e.Availability,
                role = e.Role,
                status = e.Status,
                startdate = e.StartDate,
                homeaddress = e.HomeAddress,
                reportsto = e.ReportsTo,
                emailaddress = e.EmailAddress,
                dob = e.Dob,
                passportdate = e.PassportDate,
                salarydate = e.SalaryDate,
                medicalinsurancedate = e.MedicalInsuranceDate,
               eidadate = e.EidaDate,
                objective = e.Objective

            }).ToList();

            // Build ///*******the file content
            var employeecsv = new StringBuilder();
            employeeRecords.ForEach(line =>
            {
                employeecsv.AppendLine(string.Join(",", line));
            });

            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", comlumHeadrs)}\r\n{employeecsv.ToString()}");
            return File(buffer, "text/csv", $"Employee.csv");

        }
        [Route("excel")]
        public IActionResult Excel()
        {

            var comlumHeadrs = new string[]
            {

                "Id",
                "Name",
                "Location",
                "Availability",
                "Role",
                    "Status",
                    "StartDate",
                    "HomeAddress",
                    "ReportsTo",
                    "EmailAddress",
                    "Dob",
                    "PassportDate",
                    "SalaryDate",
                    "MedicalInsuranceDate",
                    "EidaDate",


                    "Objective"
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
                var employeeRecords = (db.AlternateEmployee.Select(e => new
                {
                    id = e.Id,
                    name = e.Name,
                    location = e.Location,
                    availability = e.Availability,
                    role = e.Role,
                    status = e.Status,
                    startdate = e.StartDate,
                    homeaddress = e.HomeAddress,
                    reportsto = e.ReportsTo,
                    emailaddress = e.EmailAddress,
                    dob = e.Dob,
                    passportdate = e.PassportDate,
                    salarydate = e.SalaryDate,
                    medicalinsurancedate = e.MedicalInsuranceDate,
                    eidadate = e.EidaDate,
                    objective = e.Objective


                }).ToList());
                foreach (var employee in employeeRecords)
                {
                    worksheet.Cells["A" + j].Value = employee.id;
                    worksheet.Cells["B" + j].Value = employee.name;
                    worksheet.Cells["C" + j].Value = employee.location;
                    worksheet.Cells["D" + j].Value = employee.availability;
                    worksheet.Cells["E" + j].Value = employee.role;
                    worksheet.Cells["F" + j].Value = employee.status;
                    worksheet.Cells["G" + j].Value = employee.startdate;
                    worksheet.Cells["H" + j].Value = employee.homeaddress;
                    worksheet.Cells["I" + j].Value = employee.reportsto;
                    worksheet.Cells["J" + j].Value = employee.emailaddress;
                    worksheet.Cells["K" + j].Value = employee.dob;
                    worksheet.Cells["L" + j].Value = employee.passportdate;
                    worksheet.Cells["M" + j].Value = employee.salarydate;
                    worksheet.Cells["N" + j].Value = employee.medicalinsurancedate;
                    worksheet.Cells["O" + j].Value = employee.eidadate;
                    worksheet.Cells["P" + j].Value = employee.objective;
                    j++;
                }
                result = package.GetAsByteArray();

                worksheet.Cells["E1"].Value = 1;
                worksheet.Cells["E2"].Value = 2;
                worksheet.Cells["E3"].Value = 3;




            }

            return File(result, "application/ms-excel", $"Employee.xlsx");
        }

    }
}