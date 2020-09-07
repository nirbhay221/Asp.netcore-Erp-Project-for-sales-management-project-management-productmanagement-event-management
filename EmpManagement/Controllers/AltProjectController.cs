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
    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("AltProject")]
    public class AltProjectController : Controller
    {
        public AppDbContext db;
        public AltProjectController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.AltProject = db.AltProject.ToList();
            return View();
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Search(int page = 1, int pageSize = 3)
        {

            var keyword = Request.Query["keyword"].ToString();
            var altprojects = db.AltProject.Where(p => p.Name.Contains(keyword));
            PagedList<AltProject> model = new PagedList<AltProject>(altprojects, page, pageSize);
            ViewBag.keyword = keyword;
            return View("SearchIndex", model);
        }
        [Route("searchindex")]
        public IActionResult SearchIndex()
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
        public IActionResult Add(AltProject AltProject)
        {
            db.AltProject.Add(AltProject);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.AltProject.Remove(db.AltProject.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.AltProject.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, AltProject AltProject)
        {
            db.Entry(AltProject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}