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
    [Route("blocked")]
    public class BlockedController : Controller
    {

        public AppDbContext db;
        public BlockedController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            ViewBag.Blocked = db.Blocked.ToList();
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
        public IActionResult Add(Blocked Blocked,AltProject AltProject)
        {
            db.Blocked.Add(Blocked);
            db.AltProject.Add(AltProject);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.AltProject.Remove(db.AltProject.Find(id));
            db.Blocked.Remove(db.Blocked.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.Blocked.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Blocked Blocked,AltProject AltProject)
        {
            db.Entry(Blocked).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Entry(AltProject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}