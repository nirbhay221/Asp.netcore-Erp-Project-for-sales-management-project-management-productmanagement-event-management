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
    [Route("notininventory")]
    public class NotInInventoryController : Controller
    { public AppDbContext db;
        public NotInInventoryController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.NotInInventory = db.NotInInventory.ToList();
            return View();
        }
        [Route("findall")]
        public IActionResult FindAllNotInInventory()
        {
            var notininventory = db.NotInInventory.Select(i => new
            {
                id = i.Id,
                title = i.Name,
                description = i.Status,
                start = i.RentedFrom.ToString("dd/MM/yyyy"),
                end = i.RentedTo.ToString("dd/MM/yyyy")


            }).ToList();
            return new JsonResult(notininventory);
        }
        [Route("nextnextindex")]
        public IActionResult NextNextIndex()
        {
            ViewBag.NotInInventory = db.NotInInventory.ToList();
            return View();
        }
        [Route("nextindex")]
        public IActionResult NextIndex()
        {
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
        public IActionResult Add(NotInInventory NotInInventory,AltProduct AltProduct)
        {
            db.NotInInventory.Add(NotInInventory);
            db.AltProduct.Add(AltProduct);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.NotInInventory.Remove(db.NotInInventory.Find(id));
            db.AltProduct.Remove(db.AltProduct.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.NotInInventory.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, NotInInventory NotInInventory,AltProduct AltProduct)
        {
            db.Entry(NotInInventory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Entry(AltProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}