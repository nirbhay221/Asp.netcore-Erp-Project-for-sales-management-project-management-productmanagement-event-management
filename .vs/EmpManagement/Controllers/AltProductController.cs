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
    [Route("altproduct")]
    public class AltProductController : Controller
    {
        public AppDbContext db;
        public AltProductController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("findall")]
        public IActionResult FindAllAltProduct()
        {
            var AltProduct = db.AltProduct.Select(i => new
            {
                id = i.Id,
                title = i.Name,
                description = i.Status,
                start = i.RentedFrom.ToString("dd/MM/yyyy"),
                end = i.RentedTo.ToString("dd/MM/yyyy")


            }).ToList();
            return new JsonResult(AltProduct);
        }
        [Route("nextnextindex")]
        public IActionResult NextNextIndex()
        {
            ViewBag.AltProduct = db.AltProduct.ToList();
            return View();
        }

        [Route("nextindex")]
        public IActionResult NextIndex()
        {
            ViewBag.AltProduct = db.AltProduct.ToList();
            return View();
        }

        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.AltProduct = db.AltProduct.ToList();
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
        public IActionResult Add(AltProduct AltProduct)
        {
            db.AltProduct.Add(AltProduct);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.AltProduct.Remove(db.AltProduct.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
     
        [HttpGet]
        [Route("search")]
        public IActionResult Search(int page = 1, int pageSize = 3)
        {

            var keyword = Request.Query["keyword"].ToString();
            var altproducts = db.AltProduct.Where(p => p.Name.Contains(keyword));
            PagedList<AltProduct> model = new PagedList<AltProduct>(altproducts, page, pageSize);
            ViewBag.keyword = keyword;
            return View("SearchIndex", model);
        }

        [Route("searchindex")]
        public IActionResult SearchIndex()
        {
            return View();
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.AltProduct.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, AltProduct AltProduct)
        {
            db.Entry(AltProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}