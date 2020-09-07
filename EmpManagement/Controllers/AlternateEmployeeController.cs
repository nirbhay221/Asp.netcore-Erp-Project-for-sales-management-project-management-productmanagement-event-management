using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace EmpManagement.Controllers
{
  [Route("alternateemployee")]
    public class AlternateEmployeeController : Controller
    {
        public AppDbContext db;
        public AlternateEmployeeController(AppDbContext _db)
        {
            db = _db;
        }
        [Authorize(Roles = "Manager")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.AlternateEmployee = db.AlternateEmployee.ToList();
            return View();
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View("Add");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AlternateEmployee AlternateEmployee)
        {
            db.AlternateEmployee.Add(AlternateEmployee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.AlternateEmployee.Remove(db.AlternateEmployee.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.AlternateEmployee.Find(id));
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, AlternateEmployee AlternateEmployee)
        {
            db.Entry(AlternateEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("search")]
        public IActionResult Search(int page = 1, int pageSize = 3)
        {

            var keyword = Request.Query["keyword"].ToString();
            var alternateemployee = db.AlternateEmployee.Where(p => p.Name.Contains(keyword));
            PagedList<AlternateEmployee> model = new PagedList<AlternateEmployee>(alternateemployee, page, pageSize);
            ViewBag.keyword = keyword;
            return View("SearchIndex", model);
        }

        [Route("searchindex")]
        public IActionResult SearchIndex()
        {
            return View();
        }



    }
}