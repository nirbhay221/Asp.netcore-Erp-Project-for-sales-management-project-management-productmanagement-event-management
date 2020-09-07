using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using EmpManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpManagement.Controllers
{
    [Route("alternateemployeeexcel")]
    public class AlternateEmployeeExcelController : Controller
    {
        private readonly AppDbContext db;
        public AlternateEmployeeExcelController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("index")]
        [Route("")]
        [Route("~/")]

        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("importXML")]
        public async Task<IActionResult> ImportXML(IFormFile xmlFile)
        {


            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "xmls", xmlFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await xmlFile.CopyToAsync(stream);
                }
                ViewBag.AlternateEmployee = ProcessImport("xmls/" + xmlFile.FileName);
                ViewBag.result = "Done";
            }
            catch (Exception e)
            {
                ViewBag.result = e.Message;
            }


            return View("Index");
        }
        [Authorize(Roles = "Manager")]
        private List<AlternateEmployee> ProcessImport(string path)
        {
            XDocument xDocument = XDocument.Load(path);
            List<AlternateEmployee> alternateemployees = xDocument.Descendants("alternateemployee").Select
                (p => new AlternateEmployee()
                {
                    Id = Convert.ToInt32(p.Element("id").Value),
                    Name = p.Element("name").Value,
                    Location = p.Element("location").Value,
                   Availability = p.Element("availability").Value,
                    Role = p.Element("role").Value,
                    Status= p.Element("status").Value,
                    StartDate = Convert.ToDateTime(p.Element("startdate").Value),
                    HomeAddress = p.Element("homeaddress").Value,
                    ReportsTo = p.Element("reportsto").Value,
                    EmailAddress = p.Element("emailaddress").Value,
                    Dob = Convert.ToDateTime(p.Element("dob").Value),
                    PassportDate = Convert.ToDateTime(p.Element("passportdate").Value),
                   SalaryDate = Convert.ToDateTime(p.Element("salarydate").Value),
                    MedicalInsuranceDate = Convert.ToDateTime(p.Element("medicalinsurancedate").Value),
                   EidaDate = Convert.ToDateTime(p.Element("eidadate").Value),

                    Objective= p.Element("objective").Value
                }).ToList();
            foreach (var alternateemployee in alternateemployees)
            {
                var alternateemployeeInfo = db.AlternateEmployee.SingleOrDefault(p => p.Id.Equals(alternateemployee.Id));
                if (alternateemployeeInfo != null)
                {
                    alternateemployeeInfo.Id = alternateemployee.Id;
                    alternateemployeeInfo.Name = alternateemployee.Name;
                    alternateemployeeInfo.Location = alternateemployee.Location;
                    alternateemployeeInfo.Availability = alternateemployee.Availability;

                    alternateemployeeInfo.Role = alternateemployee.Role;
                    alternateemployeeInfo.Status = alternateemployee.Status;
                    alternateemployeeInfo.StartDate = alternateemployee.StartDate;
                    alternateemployeeInfo.HomeAddress = alternateemployee.HomeAddress;
                    alternateemployeeInfo.ReportsTo = alternateemployee.ReportsTo;
                    alternateemployeeInfo.EmailAddress = alternateemployee.EmailAddress;
                    alternateemployeeInfo.Dob = alternateemployee.Dob;
                    alternateemployeeInfo.PassportDate = alternateemployee.PassportDate;
                    alternateemployeeInfo.SalaryDate = alternateemployee.SalaryDate;
                    alternateemployeeInfo.MedicalInsuranceDate= alternateemployee.MedicalInsuranceDate;
                    alternateemployeeInfo.EidaDate= alternateemployee.EidaDate;
                    alternateemployeeInfo.Objective = alternateemployee.Objective;
                }
                else
                {
                    db.AlternateEmployee.Add(alternateemployee);
                }

                db.SaveChanges();
            }
            return alternateemployees;
        }
    }
}