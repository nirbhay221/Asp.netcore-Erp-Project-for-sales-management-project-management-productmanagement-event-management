using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PagedList;

namespace EmpManagement.Controllers
{
    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("sales")]
    public class SalesController : Controller
    {
        public AppDbContext db;
        public SalesController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.Sales = db.Sales.ToList();
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
        public IActionResult Add(Sales Sales)
        {
            db.Sales.Add(Sales);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Sales.Remove(db.Sales.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.Sales.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Sales Sales)
        {
            db.Entry(Sales).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("search")]
        public IActionResult Search(int page = 1, int pageSize = 3)
        {

            var keyword = Request.Query["keyword"].ToString();
            var sales = db.Sales.Where(p => p.Name.Contains(keyword));
            PagedList<Sales> model = new PagedList<Sales>(sales, page, pageSize);
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