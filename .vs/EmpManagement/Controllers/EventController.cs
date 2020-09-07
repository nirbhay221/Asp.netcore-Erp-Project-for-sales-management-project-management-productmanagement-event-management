using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpManagement.Controllers
{
    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("event")]
    public class EventController : Controller
    {
        public AppDbContext db;
        public EventController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.Event = db.Event.ToList();
            return View();
        }

        [Route("nextindex")]
        public IActionResult NextIndex()
        {
            ViewBag.Event = db.Event.ToList();
            return View();
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Event Event)
        {
            db.Event.Add(Event);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Event.Remove(db.Event.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.Event.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Event Event)
        {
            db.Entry(Event).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Route("findall")]
        public IActionResult FindAllEvents()
        {
            var events = db.Event.Select(e => new
            {
                id = e.Id,
                title = e.Title,
                description = e.Description,
                start = e.StartDate.ToString("dd/MM/yyyy"),
                end = e.EndDate.ToString("dd/MM/yyyy")


            }).ToList();
            return new JsonResult(events);
        }
    }
}