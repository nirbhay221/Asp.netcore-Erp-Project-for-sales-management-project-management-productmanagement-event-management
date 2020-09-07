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
   
        [Authorize(Roles = "Manager,Technical,Sales")]
        [Route("salesexcel")]
        public class SalesExcelController : Controller
        {


            private readonly AppDbContext db;
            public SalesExcelController(AppDbContext _db)
            {
                db = _db;
            }
            [Route("index")]
            [Route("")]
            [Route("~/")]


            public IActionResult Index()
            {
                return View();
            }

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
                    ViewBag.Sales = ProcessImport("xmls/" + xmlFile.FileName);
                    ViewBag.result = "Done";
                }
                catch (Exception e)
                {
                    ViewBag.result = e.Message;
                }


                return View("Index");
            }
            private List<Sales> ProcessImport(string path)
            {
                var xDocument = XDocument.Load(path);
                List<Sales> saless = xDocument.Descendants("sales").Select
                    (p => new Sales()
                    {
                        Id = Convert.ToInt32(p.Element("id").Value),
                        Name = p.Element("name").Value,
                        Rep = p.Element("rep").Value,
                        SalesStage = p.Element("salesstage").Value,

                        Priority = p.Element("priority").Value,
                        ExpectedCloseDate = Convert.ToDateTime(p.Element("expectedclosedate").Value),
                        ForeCastValue = Convert.ToInt32(p.Element("forecastvalue").Value),

                        Probability = Convert.ToInt32(p.Element("probability").Value),


                        LastContact = Convert.ToDateTime(p.Element("lastcontact").Value),


                        SignedContractValue = Convert.ToInt32(p.Element("signedcontractvalue").Value),

                        Quantity = Convert.ToInt32(p.Element("quantity").Value),


                        Notes = p.Element("notes").Value
                    }).ToList();
                foreach (var sales in saless)
                {
                    var salesInfo = db.Sales.SingleOrDefault(p => p.Id.Equals(sales.Id));
                    if (salesInfo != null)
                    {
                        salesInfo.Id = sales.Id;
                        salesInfo.Name = sales.Name;
                        salesInfo.Rep = sales.Rep;
                        salesInfo.SalesStage = sales.SalesStage;

                        salesInfo.Priority = sales.Priority;
                        salesInfo.ExpectedCloseDate = sales.ExpectedCloseDate;
                        salesInfo.ForeCastValue = sales.ForeCastValue;
                        salesInfo.Probability = sales.Probability;
                        salesInfo.LastContact = sales.LastContact;
                        salesInfo.SignedContractValue = sales.SignedContractValue;
                        salesInfo.Quantity = sales.Quantity;
                        salesInfo.Notes = sales.Notes;
                    }
                    else
                    {
                        db.Sales.Add(sales);
                    }

                    db.SaveChanges();
                }
                return saless;
            }
        }
    }
