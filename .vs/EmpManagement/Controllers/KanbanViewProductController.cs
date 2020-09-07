using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpManagement.Controllers
{
    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("kanbanviewproduct")]
    public class KanbanViewProductController : Controller
    {

        public AppDbContext db;
        public KanbanViewProductController(AppDbContext _db)
        {
            db = _db;

        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.Inventory = db.Inventory.ToList();
            ViewBag.NotInInventory = db.NotInInventory.ToList();
            ViewBag.RentedForProject = db.RentedForProject.ToList();
            ViewBag.RentedFromClients = db.RentedFromClients.ToList();


            return View();
        }

        [HttpGet]
        [Route("arrowsuperone/{id}")]
        public IActionResult ArrowSuperOne(int id)
        {
            var str = db.Inventory.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "RentedFromClients";
                RentedFromClients ls = new RentedFromClients();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Price = val.Price;
                ls.Quantity = val.Quantity;
                ls.Project = val.Project;
                ls.RentedFrom = val.RentedFrom;
                ls.RentedTo = val.RentedTo;
                db.RentedFromClients.Add(ls);

            }
            db.SaveChanges();
            db.Inventory.Remove(db.Inventory.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowsupertwo/{id}")]
        public IActionResult ArrowSuperTwo(int id)
        {
            var str = db.Inventory.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "NotInInventory";
                NotInInventory ls = new NotInInventory();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Price = val.Price;
                ls.Quantity = val.Quantity;
                ls.Project = val.Project;
                ls.RentedFrom = val.RentedFrom;
                ls.RentedTo = val.RentedTo;
                db.NotInInventory.Add(ls);

            }
            db.SaveChanges();
            db.Inventory.Remove(db.Inventory.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowsuperthree/{id}")]
        public IActionResult ArrowSuperThree(int id)
        {
            var str = db.NotInInventory.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "Inventory";
                Inventory ls = new Inventory();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Price = val.Price;
                ls.Quantity = val.Quantity;
                ls.Project = val.Project;
                ls.RentedFrom = val.RentedFrom;
                ls.RentedTo = val.RentedTo;
                db.Inventory.Add(ls);

            }
            db.SaveChanges();
            db.NotInInventory.Remove(db.NotInInventory.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowsuperfour/{id}")]
        public IActionResult ArrowSuperFour(int id)
        {
            var str = db.NotInInventory.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "RentedForProject";
                RentedForProject ls = new RentedForProject();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Price = val.Price;
                ls.Quantity = val.Quantity;
                ls.Project = val.Project;
                ls.RentedFrom = val.RentedFrom;
                ls.RentedTo = val.RentedTo;
                db.RentedForProject.Add(ls);

            }
            db.SaveChanges();
            db.NotInInventory.Remove(db.NotInInventory.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowsuperfive/{id}")]
        public IActionResult ArrowSuperFive(int id)
        {
            var str = db.RentedForProject.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "NotInInventory";
                NotInInventory ls = new NotInInventory();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Price = val.Price;
                ls.Quantity = val.Quantity;
                ls.Project = val.Project;
                ls.RentedFrom = val.RentedFrom;
                ls.RentedTo = val.RentedTo;
                db.NotInInventory.Add(ls);

            }
            db.SaveChanges();
            db.RentedForProject.Remove(db.RentedForProject.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowsupersix/{id}")]
        public IActionResult ArrowSuperSix(int id)
        {
            var str = db.RentedForProject.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "RentedFromClients";
                RentedFromClients ls = new RentedFromClients();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Price = val.Price;
                ls.Quantity = val.Quantity;
                ls.Project = val.Project;
                ls.RentedFrom = val.RentedFrom;
                ls.RentedTo = val.RentedTo;
                db.RentedFromClients.Add(ls);

            }
            db.SaveChanges();
            db.RentedForProject.Remove(db.RentedForProject.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowsuperseven/{id}")]
        public IActionResult ArrowSuperSeven(int id)
        {
            var str = db.RentedFromClients.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "RentedForProject";
                RentedForProject ls = new RentedForProject();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Price = val.Price;
                ls.Quantity = val.Quantity;
                ls.Project = val.Project;
                ls.RentedFrom = val.RentedFrom;
                ls.RentedTo = val.RentedTo;
                db.RentedForProject.Add(ls);

            }
            db.SaveChanges();
            db.RentedFromClients.Remove(db.RentedFromClients.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowsupereight/{id}")]
        public IActionResult ArrowSuperEight(int id)
        {
            var str = db.RentedFromClients.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "Inventory";
                Inventory ls = new Inventory();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Price = val.Price;
                ls.Quantity = val.Quantity;
                ls.Project = val.Project;
                ls.RentedFrom = val.RentedFrom;
                ls.RentedTo = val.RentedTo;
                db.Inventory.Add(ls);

            }
            db.SaveChanges();
            db.RentedFromClients.Remove(db.RentedFromClients.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}