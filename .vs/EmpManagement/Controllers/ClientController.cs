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
    [Route("client")]
    public class ClientController : Controller
    {
        public AppDbContext db;
        public ClientController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.Client = db.Client.ToList();
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
        public IActionResult Add(Client Client)
        {
            db.Client.Add(Client);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Client.Remove(db.Client.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.Client.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Client Client)
        {
            db.Entry(Client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("search")]
        public IActionResult Search(int page = 1, int pageSize = 3)
        {

            var keyword = Request.Query["keyword"].ToString();
            var clients = db.Client.Where(p => p.Name.Contains(keyword));
            PagedList<Client> model = new PagedList<Client>(clients, page, pageSize);
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