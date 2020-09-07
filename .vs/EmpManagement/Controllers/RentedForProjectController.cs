using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using PagedList;

namespace EmpManagement.Controllers
{
    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("rentedforproject")]
    public class RentedForProjectController : Controller
    {
        public AppDbContext db;
        public RentedForProjectController(AppDbContext _db)
        {
            db = _db;
        }
        [Route("index")]
        public IActionResult Index(string button)
        {
            List<RentedForProject> RentedForProject = db.RentedForProject.ToList();


            var MainRecord = from rp in RentedForProject
                             select new ViewModel
                             {
                                 RentedForProject = rp
                             };
            return new ViewAsPdf(MainRecord);


        }
        [Route("nextindex")]
        public IActionResult NextIndex()
        {
            return View();
        }

        [Route("findall")]
        public IActionResult FindAllRentedForProject()
        {
            var rentedforproject = db.RentedForProject.Select(i => new
            {
                id = i.Id,
                title = i.Name,
                description = i.Status,
                start = i.RentedFrom.ToString("dd/MM/yyyy"),
                end = i.RentedTo.ToString("dd/MM/yyyy")


            }).ToList();
            return new JsonResult(rentedforproject);
        }
        [Route("nextnextindex")]
        public IActionResult NextNextIndex()
        {
            ViewBag.RentedForProject = db.RentedForProject.ToList();
            return View();
        }
        [Route("nextnextnextnextindex")]
        public IActionResult NextNextNextNextIndex()
        {
            ViewBag.RentedForProject = db.RentedForProject.ToList();
           // List<RentedForProject> RentedForProject = db.RentedForProject.ToList();


            //var MainRecord = from rp in RentedForProject
              //               select new ViewModel
                  //           {
                //                 RentedForProject = rp
                    //         };
            return  View();
        }
        [Route("nextnextnextindex")]
        public IActionResult NextNextNextIndex()
        {
            ViewBag.RentedForProject = db.RentedForProject.ToList();
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
        public IActionResult Add(RentedForProject RentedForProject,AltProduct AltProduct)
        {
            db.RentedForProject.Add(RentedForProject);
            db.AltProduct.Add(AltProduct);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.RentedForProject.Remove(db.RentedForProject.Find(id));
            db.AltProduct.Remove(db.AltProduct.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {

            return View("Edit", db.RentedForProject.Find(id));
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, RentedForProject RentedForProject,AltProduct AltProduct)
        {
            db.Entry(RentedForProject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Entry(AltProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Search(int page = 1, int pageSize = 3)
        {

            var keyword = Request.Query["keyword"].ToString();
            var rentedforproject = db.RentedForProject.Where(p => p.Project.Contains(keyword));
            PagedList<RentedForProject> model = new PagedList<RentedForProject>(rentedforproject, page, pageSize);
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