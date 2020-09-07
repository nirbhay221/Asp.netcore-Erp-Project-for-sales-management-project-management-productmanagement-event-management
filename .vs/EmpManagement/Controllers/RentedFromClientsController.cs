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
    [Route("rentedfromclients")]
    public class RentedFromClientsController : Controller
    {
        public AppDbContext db;
        public RentedFromClientsController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("findall")]
        public IActionResult FindAllRentedFromClients()
        {
            var rentedfromclients = db.RentedFromClients.Select(i => new
            {
                id = i.Id,
                title = i.Name,
                description = i.Status,
                start = i.RentedFrom.ToString("dd/MM/yyyy"),
                end = i.RentedTo.ToString("dd/MM/yyyy")


            }).ToList();
            return new JsonResult(rentedfromclients);
        }
        [Route("nextnextindex")]
        public IActionResult NextNextIndex()
        {
            ViewBag.RentedFromClients = db.RentedFromClients.ToList();
            return View();
        }
        public IActionResult Index()
        {
            ViewBag.RentedFromClients = db.RentedFromClients.ToList();
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
        public IActionResult Add(RentedFromClients RentedFromClients,AltProduct AltProduct)
        {
            db.RentedFromClients.Add(RentedFromClients);
            db.AltProduct.Add(AltProduct);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.RentedFromClients.Remove(db.RentedFromClients.Find(id));

            db.AltProduct.Remove(db.AltProduct.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.RentedFromClients.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, RentedFromClients RentedFromClients,AltProduct AltProduct)
        {
            db.Entry(RentedFromClients).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Entry(AltProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}