using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpManagement.Controllers
{
    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("kanbanviewproject")]
    public class KanbanViewProjectController : Controller
    {
        public AppDbContext db;
        public KanbanViewProjectController(AppDbContext _db)
        {
            db = _db;

        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.UpNext = db.UpNext.ToList();
            ViewBag.OnTrack = db.OnTrack.ToList();
            ViewBag.Behind = db.Behind.ToList();
            ViewBag.AtRisk = db.AtRisk.ToList();
            ViewBag.Blocked = db.Blocked.ToList();
            ViewBag.Complete = db.Complete.ToList();
           
          
            return View();
        }

        [HttpGet]
        [Route("arrowone/{id}")]
        public IActionResult ArrowOne(int id)
        {
            var str = db.UpNext.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "Complete";
                Complete ls = new Complete();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;
                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.Complete.Add(ls);

            }
            db.SaveChanges();
            db.UpNext.Remove(db.UpNext.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowtwo/{id}")]
        public IActionResult ArrowTwo(int id)
        {
            var str = db.UpNext.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "OnTrack";
                OnTrack ls = new OnTrack();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.OnTrack.Add(ls);

            }
            db.SaveChanges();
            db.UpNext.Remove(db.UpNext.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowthree/{id}")]
        public IActionResult ArrowThree(int id)
        {
            var str = db.OnTrack.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "UpNext";
                UpNext ls = new UpNext();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.UpNext.Add(ls);

            }
            db.SaveChanges();
            db.OnTrack.Remove(db.OnTrack.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowfour/{id}")]
        public IActionResult ArrowFour(int id)
        {
            var str = db.OnTrack.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "Behind";
                Behind ls = new Behind();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.Behind.Add(ls);

            }
            db.SaveChanges();
            db.OnTrack.Remove(db.OnTrack.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowfive/{id}")]
        public IActionResult ArrowFive(int id)
        {
            var str = db.Behind.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "OnTrack";
                OnTrack ls = new OnTrack();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.OnTrack.Add(ls);

            }
            db.SaveChanges();
            db.Behind.Remove(db.Behind.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrowsix/{id}")]
        public IActionResult ArrowSix(int id)
        {
            var str = db.Behind.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "AtRisk";
                AtRisk ls = new AtRisk();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.AtRisk.Add(ls);

            }
            db.SaveChanges();
            db.Behind.Remove(db.Behind.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowseven/{id}")]
        public IActionResult ArrowSeven(int id)
        {
            var str = db.AtRisk.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "Behind";
                Behind ls = new Behind();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.Behind.Add(ls);

            }
            db.SaveChanges();
            db.AtRisk.Remove(db.AtRisk.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arroweight/{id}")]
        public IActionResult ArrowEight(int id)
        {
            var str = db.AtRisk.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "Blocked";
                Blocked ls = new Blocked();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.Blocked.Add(ls);

            }
            db.SaveChanges();
            db.AtRisk.Remove(db.AtRisk.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("arrownine/{id}")]
        public IActionResult ArrowNine(int id)
        {
            var str = db.Blocked.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "AtRisk";
                AtRisk ls = new AtRisk();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db. AtRisk.Add(ls);

            }
            db.SaveChanges();
            db.Blocked.Remove(db.Blocked.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowten/{id}")]
        public IActionResult ArrowTen(int id)
        {
            var str = db.Blocked.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "Complete";
                Complete ls = new Complete();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.Complete.Add(ls);

            }
            db.SaveChanges();
            db.Blocked.Remove(db.Blocked.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowtwelve/{id}")]
        public IActionResult ArrowTwelve(int id)
        {
            var str = db.Complete.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "UpNext";
                UpNext ls = new UpNext();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.UpNext.Add(ls);

            }
            db.SaveChanges();
            db.Complete.Remove(db.Complete.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arroweleven/{id}")]
        public IActionResult ArrowEleven(int id)
        {
            var str = db.Complete.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string Status = "Blocked";
                Blocked ls = new Blocked();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Status = Status;
                ls.Category = val.Category;
                ls.Owner = val.Owner;
                ls.Lead = val.Lead;

                ls.Budget = val.Budget;
                ls.Profit = val.Profit;
                db.Blocked.Add(ls);

            }
            db.SaveChanges();
            db.Complete.Remove(db.Complete.Find(id));

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}