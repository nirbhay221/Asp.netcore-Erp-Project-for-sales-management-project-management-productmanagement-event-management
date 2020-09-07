using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace EmpManagement.Controllers
{
    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("inventory")]
    public class InventoryController : Controller
    {
        public AppDbContext db;
        public InventoryController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            ViewBag.Inventory = db.Inventory.ToList();
            return  View();
        }
        [Route("findall")]
        public IActionResult FindAllInventory()
        {
            var inventory = db.Inventory.Select(i => new
            {
                id = i.Id,
                title = i.Name,
                description = i.Status,
                start = i.RentedFrom.ToString("dd/MM/yyyy"),
                end = i.RentedTo.ToString("dd/MM/yyyy")


            }).ToList();
            return new JsonResult(inventory);
        }
        [Route("nextnextindex")]
        public IActionResult NextNextIndex()
        {
            ViewBag.Inventory = db.Inventory.ToList();
            return View();
        }

        [Route("nextindex")]
        public IActionResult NextIndex()
        {
            ViewBag.Inventory = db.Inventory.ToList();
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
        public IActionResult Add(Inventory Inventory,AltProduct AltProduct)
        {
            db.Inventory.Add(Inventory);
            db.AltProduct.Add(AltProduct);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Inventory.Remove(db.Inventory.Find(id));
            db.AltProduct.Remove(db.AltProduct.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.Inventory.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Inventory Inventory,AltProduct AltProduct)
        {
            db.Entry(Inventory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Entry(AltProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}