using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
namespace EmpManagement.Controllers
{
    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("negotiation")]
    public class NegotiationController : Controller
    {

        public AppDbContext db;
        public NegotiationController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.Negotiation = db.Negotiation.ToList();
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
        public IActionResult Add(Negotiation Negotiation, Sales Sales)
        {
            db.Negotiation.Add(Negotiation);
            db.Sales.Add(Sales);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Negotiation.Remove(db.Negotiation.Find(id));

            db.Sales.Remove(db.Sales.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.Negotiation.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Negotiation Negotiation, Sales Sales)
        {
            db.Entry(Negotiation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.Entry(Sales).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}