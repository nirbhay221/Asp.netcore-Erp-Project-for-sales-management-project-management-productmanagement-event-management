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
    [Route("projectclient")]
    public class ProjectClientController : Controller
    {
        private AppDbContext db;
        public ProjectClientController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("")]
        [Route("index")]
        [Route("~/")]

        public IActionResult Index()
        {
            ViewBag.projectclient = db.ProjectClient.ToList();
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
        public IActionResult Add(ProjectClient ProjectClient)
        {
            db.ProjectClient.Add(ProjectClient);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.ProjectClient.Remove(db.ProjectClient.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.ProjectClient.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, ProjectClient ProjectClient)
        {
            db.Entry(ProjectClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}