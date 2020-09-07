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
    [Route("eventexcel")]
    public class EventExcelController : Controller
    {


        private readonly AppDbContext db;
        public EventExcelController(AppDbContext _db)
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
                ViewBag.Events = ProcessImport("xmls/" + xmlFile.FileName);
                ViewBag.result = "Done";
            }
            catch (Exception e)
            {
                ViewBag.result = e.Message;
            }


            return View("Index");
        }
        private List<Event> ProcessImport(string path)
        {
            var xDocument = XDocument.Load(path);
            List<Event> events = xDocument.Descendants("Event").Select
                (p => new Event()
                {
                    Id = Convert.ToInt32( p.Element("id").Value),
                    Title = p.Element("title").Value,
                    Description = p.Element("description").Value,
                    StartDate = Convert.ToDateTime(p.Element("startdate").Value),

                    EndDate = Convert.ToDateTime(p.Element("enddate").Value),
                    Budget = Convert.ToInt32(p.Element("budget").Value),
                    Profit = Convert.ToInt32(p.Element("profit").Value),

                    Location = p.Element("location").Value

                }).ToList();
            foreach (var Event in events)
            {
                var eventInfo = db.Event.SingleOrDefault(p => p.Id.Equals(Event.Id));
                if (eventInfo != null)
                {
                    eventInfo.Id = Event.Id;
        eventInfo.Title = Event.Title;
        eventInfo.Description = Event.Description;
        eventInfo.StartDate = Event.StartDate;

        eventInfo.EndDate = Event.EndDate;
        eventInfo.Budget= Event.Budget;
        eventInfo.Profit = Event.Profit;
        eventInfo.Location = Event.Location;
        }
                    else
                    {
                        db.Event.Add(Event);
        }

        db.SaveChanges();
                }
                return events;
        }
    }
}