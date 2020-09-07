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
    [Route("closedlost")]
    public class ClosedLostController : Controller
    {

        public AppDbContext db;
        public ClosedLostController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.ClosedLost = db.ClosedLost.ToList();
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
        public IActionResult Add(ClosedLost ClosedLost, Sales Sales)
        {
            db.ClosedLost.Add(ClosedLost);
            db.Sales.Add(Sales);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.ClosedLost.Remove(db.ClosedLost.Find(id));

            db.Sales.Remove(db.Sales.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.ClosedLost.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, ClosedLost ClosedLost, Sales Sales)
        {
            db.Entry(ClosedLost).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.Entry(Sales).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}