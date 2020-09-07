using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddinDragAndDropToToDoList.Controllers
{


    [Route("coast")]
    public class CoastController : Controller
    {
        public AppDbContext db; 
        public CoastController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("")]
        [Route("index")]
        [Route("~/")]

        public IActionResult Index()
        {
            ViewBag.CoastStatus = db.CoastStatus.ToList();
            return View("Index");
        }


        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {

            ViewBag.CoastStatus = db.CoastStatus.ToList();
            ViewBag.Coast = db.Coast.ToList();
            return View("Add");
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Coast Coast)
        {
            db.Coast.Add(Coast);
            db.SaveChanges();

            return RedirectToAction("Add");
        }

        [HttpGet]
        [Route("Addo")]
        public IActionResult Addo()
        {

            List<Coast> Coast = db.Coast.ToList();
            ViewBag.Coasts = Coast.ToList();
            return View("Addo");
        }
        [HttpPost]
        [Route("Addo")]
        public IActionResult Addo(Coast Coast)
        {
            db.Coast.Add(Coast);
            db.SaveChanges();

            return RedirectToAction("Addo");
        }

        [HttpGet]
        [Route("Addyo")]
        public IActionResult Addyo()
        {
            return View("Add");
        }
        [HttpPost]
        [Route("Addyo")]
        public IActionResult Addyo(Coast Coast)
        {
            db.Coast.Add(Coast);
            db.SaveChanges();

            return RedirectToAction("Add");
        }

        [HttpGet]
        [Route("AddPlease")]
        public IActionResult AddPlease()
        {
            return View("Add");
        }
        [HttpPost]
        [Route("AddPlease")]
        public IActionResult AddPlease(Coast Coast)
        {
            db.Coast.Add(Coast);
            db.SaveChanges();

            return RedirectToAction("Add");
        }
        [HttpGet]
        [Route("AddWork")]
        public IActionResult AddWork()
        {
            return View("Add");
        }
        [HttpPost]
        [Route("AddWork")]
        public IActionResult AddWork(Coast Coast)
        {
            db.Coast.Add(Coast);
            db.SaveChanges();

            return RedirectToAction("Add");
        }
        [HttpGet]
        [Route("ChangeAdd")]
        public IActionResult ChangeAdd()
        {
            return View("ChangeAdd");
        }
        [HttpPost]
        [Route("ChangeAdd")]
        public IActionResult ChangeAdd(Coast Coast)
        {
            db.Coast.Add(Coast);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.CoastStatus.Remove(db.CoastStatus.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.CoastStatus.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, CoastStatus CoastStatus)
        {
            db.Entry(CoastStatus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}