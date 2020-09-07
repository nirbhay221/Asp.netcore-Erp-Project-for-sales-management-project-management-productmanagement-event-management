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
    [Route("jacket")]
    public class JacketController : Controller
    {
        public AppDbContext db;
        public JacketController(AppDbContext _db)
        {
            db = _db;
        }
        [Authorize(Roles ="Manager")]
        [Route("")]
        [Route("index")]
        [Route("~/")]

        public IActionResult Index()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.ToList();
            return View();
        }
        [Authorize(Roles = "Sales,Manager")]

        [Route("salesindex")]
        public IActionResult SalesIndex()
        { 
            ViewBag.Jackets = db.Jacket.Where(p => p.Role.Contains("Sales"));
            return View();
        }

        [Authorize(Roles = "Technical,Manager")]
        [Route("technicalindex")]
        public IActionResult TechnicalIndex()
        {

            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = db.Jacket.Where(p => p.Role.Contains("Technical"));
            return View();
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("AddSortByName")]
        public IActionResult AddSortByName()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Name).ToList();
            return View("AddSortByName");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("AddSortByName")]
        public IActionResult AddSortByName(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("SalesAddSortByName")]
        public IActionResult SalesAddSortByName()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Name).ToList();
            return View("SalesAddSortByName");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("SalesAddSortByName")]
        public IActionResult SalesAddSortByName(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("SalesIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("TechnicalAddSortByName")]
        public IActionResult TechnicalAddSortByName()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Name).ToList();
            return View("TechnicalAddSortByName");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("TechnicalAddSortByName")]
        public IActionResult TechnicalAddSortByName(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("TechnicalIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("search")]
        public IActionResult Search(int page = 1, int pageSize = 3)
        {

            var keyword = Request.Query["keyword"].ToString();
            var jackets = db.Jacket.Where(p => p.Name.Contains(keyword));
            PagedList<Jacket> model = new PagedList<Jacket>(jackets, page, pageSize);
            ViewBag.keyword = keyword;
            return View("SearchIndex", model);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult SearchIndex()
        {
            return View();
        }
        [Authorize(Roles = "Sales,Manager")]
        [HttpGet]
        [Route("searchsales")]
        public IActionResult SearchSales(int page = 1, int pageSize = 3)
        {
            var keyword = Request.Query["keyword"].ToString();
            var Jocket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            var jackets = Jocket.Where(p => p.Name.Contains(keyword));
            PagedList<Jacket> model = new PagedList<Jacket>(jackets, page, pageSize);
            ViewBag.keyword = keyword;
            return View("SearchSalesIndex", model);
        }
        [Authorize(Roles = "Sales,Manager")]
        public IActionResult SearchSalesIndex()
        {
            return View();
        }
        [Authorize(Roles = "Technical,Manager")]
        [HttpGet]
        [Route("searchtechnical")]
        public IActionResult SearchTechnical(int page = 1, int pageSize = 3)
        {
            var keyword = Request.Query["keyword"].ToString();
            var Jocket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            var jackets = Jocket.Where(p => p.Name.Contains(keyword));
            PagedList<Jacket> model = new PagedList<Jacket>(jackets, page, pageSize);
            ViewBag.keyword = keyword;
            return View("SearchTechnicalIndex", model);
        }
        [Authorize(Roles = "Technical,Manager")]
        public IActionResult SearchTechnicalIndex()
        {
            return View();
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("AddSortByDescription")]
        public IActionResult AddSortByDescription()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Description).ToList();
            return View("AddSortByDescription");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("AddSortByDescription")]
        public IActionResult AddSortByDescription(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("AddSortByPriority")]
        public IActionResult AddSortByPriority()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Priority).ToList();
            return View("AddSortByPriority");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("AddSortByPriority")]
        public IActionResult AddSortByPriority(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("AddSortByRole")]
        public IActionResult AddSortByRole()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Role).ToList();
            return View("AddSortByRole");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("AddSortByRole")]
        public IActionResult AddSortByRole(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("AddSortByStatus")]
        public IActionResult AddSortByStatus()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Status).ToList();
            return View("AddSortByStatus");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("AddSortByStatus")]
        public IActionResult AddSortByStatus(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Sales")]
        [HttpGet]
        [Route("SalesAddSortByDescription")]
        public IActionResult SalesAddSortByDescription()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Description).ToList();
            return View("SalesAddSortByDescription");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("SalesAddSortByDescription")]
        public IActionResult SalesAddSortByDescription(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("SalesIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("SalesAddSortByPriority")]
        public IActionResult SalesAddSortByPriority()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Priority).ToList();
            return View("SalesAddSortByPriority");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("SalesAddSortByPriority")]
        public IActionResult SalesAddSortByPriority(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("SalesIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("SalesAddSortByRole")]
        public IActionResult SalesAddSortByRole()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Role).ToList();
            return View("SalesAddSortByRole");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("SalesAddSortByRole")]
        public IActionResult SalesAddSortByRole(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("SalesIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("SalesAddSortByStatus")]
        public IActionResult SalesAddSortByStatus()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Status).ToList();
            return View("SalesAddSortByStatus");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("SalesAddSortByStatus")]
        public IActionResult SalesAddSortByStatus(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("SalesIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("TechnicalAddSortByDescription")]
        public IActionResult TechnicalAddSortByDescription()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Description).ToList();
            return View("TechnicalAddSortByDescription");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("TechnicalAddSortByDescription")]
        public IActionResult TechnicalAddSortByDescription(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("TechnicalIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("TechnicalAddSortByPriority")]
        public IActionResult TechnicalAddSortByPriority()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Priority).ToList();
            return View("TechnicalAddSortByPriority");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("TechnicalAddSortByPriority")]
        public IActionResult TechnicalAddSortByPriority(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("TechnicalIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("TechnicalAddSortByRole")]
        public IActionResult TechnicalAddSortByRole()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Role).ToList();
            return View("TechnicalAddSortByRole");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("TechnicalAddSortByRole")]
        public IActionResult TechnicalAddSortByRole(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("TechnicalIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("TechnicalAddSortByStatus")]
        public IActionResult TechnicalAddSortByStatus()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Status).ToList();
            return View("TechnicalAddSortByStatus");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("TechnicalAddSortByStatus")]
        public IActionResult TechnicalAddSortByStatus(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("TechnicalIndex");
        }


        [Authorize(Roles ="Manager")]
        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.ToList();
            return View("Add");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("salesAdd")]
        public IActionResult SalesAdd()
        {
            ViewBag.Jackets = db.Jacket.Where(p => p.Role.Contains("Sales"));
            return View("Add");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("salesAdd")]
        public IActionResult SalesAdd(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("SalesIndex");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("technicalAdd")]
        public IActionResult TechnicalAdd()
        {
            ViewBag.Jackets = db.Jacket.Where(p => p.Role.Contains("Technical"));
            return View("Add");
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("technicalAdd")]
        public IActionResult TechnicalAdd(Jacket Jacket)
        {
            db.Jacket.Add(Jacket);
            db.SaveChanges();

            return RedirectToAction("TechnicalIndex");
        }
        [Authorize(Roles = "Manager")]
        [Route("SortByName")]

        public IActionResult SortByName()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Name).ToList();
            return View("SortByName");
        }
        [Authorize(Roles = "Manager,Sales")]
        [Route("SalesSortByName")]

        public IActionResult SalesSortByName()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Name).ToList();
            return View("SalesSortByName");
        }
        [Authorize(Roles = "Technical,Manager")]
        [Route("TechnicalSortByName")]

        public IActionResult TechnicalSortByName()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Name).ToList();
            return View("TechnicalSortByName");
        }
        [Authorize(Roles = "Manager")]
        [Route("SortByStatus")]

        public IActionResult SortByStatus()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Status).ToList();
            return View("SortByStatus");
        }
        [Authorize(Roles = "Manager")]
        [Route("SortById")]

        public IActionResult SortById()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Id).ToList();
            return View("SortById");
        }
        [Authorize(Roles = "Manager")]
        [Route("SortByPriority")]

        public IActionResult SortByPriority()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Priority).ToList();
            return View("SortByPriority");
        }
        [Authorize(Roles = "Manager")]
        [Route("SortByRole")]

        public IActionResult SortByRole()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Role).ToList();
            return View("SortByRole");
        }
        [Authorize(Roles = "Manager")]
        [Route("SortByDescription")]

        public IActionResult SortByDescription()
        {
            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Description).ToList();
            return View("SortByDescription");
        }
        [Authorize(Roles = "Sales,Manager")]
        [Route("SalesSortByStatus")]
        public IActionResult SalesSortByStatus()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Status).ToList();
            return View("SalesSortByStatus");
        }
        [Authorize(Roles = "Sales,Manager")]
        [Route("SalesSortById")]

        public IActionResult SalesSortById()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Id).ToList();
            return View("SalesSortById");
        }
        [Authorize(Roles = "Sales,Manager")]
        [Route("SalesSortByPriority")]

        public IActionResult SalesSortByPriority()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Priority).ToList();
            return View("SalesSortByPriority");
        }
        [Authorize(Roles = "Sales,Manager")]
        [Route("SalesSortByRole")]

        public IActionResult SalesSortByRole()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Role).ToList();
            return View("SalesSortByRole");
        }
        [Authorize(Roles = "Sales,Manager")]
        [Route("SalesSortByDescription")]

        public IActionResult SalesSortByDescription()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Sales"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Description).ToList();
            return View("SalesSortByDescription");
        }
        [Authorize(Roles = "Technical,Manager")]
        [Route("TechnicalSortByStatus")]
        public IActionResult TechnicalSortByStatus()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Status).ToList();
            return View("TechnicalSortByStatus");
        }
        [Authorize(Roles = "Technical,Manager")]
        [Route("TechnicalSortById")]

        public IActionResult TechnicalSortById()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Id).ToList();
            return View("TechnicalSortById");
        }
        [Authorize(Roles = "Technical,Manager")]
        [Route("TechnicalortByPriority")]

        public IActionResult TechnicalSortByPriority()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Priority).ToList();
            return View("TechnicalSortByPriority");
        }
        [Authorize(Roles = "Technical,Manager")]
        [Route("TechnicalSortByRole")]

        public IActionResult TechnicalSortByRole()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Role).ToList();
            return View("TechnicalSortByRole");
        }
        [Authorize(Roles = "Technical,Manager")]
        [Route("TechnicalSortByDescription")]

        public IActionResult TechnicalSortByDescription()
        {
            var Jacket = db.Jacket.Where(p => p.Role.Contains("Technical"));
            ViewBag.Jackets = Jacket.OrderBy(x => x.Description).ToList();
            return View("TechnicalSortByDescription");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Jacket.Remove(db.Jacket.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.ToList();
            return View("Edit", db.Jacket.Find(id));
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Jacket Jacket)
        {
            db.Entry(Jacket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Sales,Manager")]
        [HttpGet]
        [Route("salesedit/{id}")]
        public IActionResult SalesEdit(int id)
        {

            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = db.Jacket.Where(p => p.Role.Contains("Sales"));
            return View("Edit", db.Jacket.Find(id));
        }
        [Authorize(Roles = "Sales,Manager")]
        [HttpPost]
        [Route("salesedit/{id}")]
        public IActionResult SalesEdit(int id, Jacket Jacket)
        {
            db.Entry(Jacket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Technical,Manager")]
        [HttpGet]
        [Route("technicaledit/{id}")]
        public IActionResult TechnicalEdit(int id)
        {

            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = db.Jacket.Where(p => p.Role.Contains("Technical"));
            return View("Edit", db.Jacket.Find(id));
        }
        [Authorize(Roles = "Technical,Manager")]
        [HttpPost]
        [Route("technicaledit/{id}")]
        public IActionResult TechnicalEdit(int id, Jacket Jacket)
        {
            db.Entry(Jacket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("editSortByName/{id}")]
        public IActionResult EditSortByName(int id)
        {

            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Name).ToList();
            return View("EditSortByName", db.Jacket.Find(id));
        }
        [Authorize(Roles = "Manager")]

        [HttpPost]
        [Route("editSortByName/{id}")]
        public IActionResult EditSortByName(int id, Jacket Jacket)
        {
            db.Entry(Jacket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]

        [HttpGet]
        [Route("editSortByStatus/{id}")]
        public IActionResult EditSortByStatus(int id)
        {

            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Status).ToList();
            return View("EditSortByStatus", db.Jacket.Find(id));
        }
        [Authorize(Roles = "Manager")]

        [HttpPost]
        [Route("editSortByStatus/{id}")]
        public IActionResult EditSortByStatus(int id, Jacket Jacket)
        {
            db.Entry(Jacket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("editSortByDescription/{id}")]
        public IActionResult EditSortByDescription(int id)
        {

            List<Jacket> Jacket = db.Jacket.ToList();
            ViewBag.Jackets = Jacket.OrderBy(x => x.Description).ToList();
            return View("EditSortByDescription", db.Jacket.Find(id));
        }
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [Route("editSortByDescription/{id}")]
        public IActionResult EditSortByDescription(int id, Jacket Jacket)
        {
            db.Entry(Jacket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}