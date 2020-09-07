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
    [Route("productsales")]
        public class ProductSalesController : Controller
        {
        private AppDbContext db;
            public ProductSalesController(AppDbContext _db)
        {
            db = _db;
        }
            [Route("")]
            [Route("index")]
            [Route("~/")]

            public IActionResult Index()
            {
                ViewBag.productsales = db.ProductSales.ToList();
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
            public IActionResult Add(ProductSales ProductSales)
            {
                db.ProductSales.Add(ProductSales);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            [HttpGet]
            [Route("delete/{id}")]
            public IActionResult Delete(int id)
            {
                db.ProductSales.Remove(db.ProductSales.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            [HttpGet]
            [Route("edit/{id}")]
            public IActionResult Edit(int id)
            {

                return View("Edit", db.ProductSales.Find(id));
            }
            [HttpPost]
            [Route("edit/{id}")]
            public IActionResult Edit(int id, ProductSales ProductSales)
            {
                db.Entry(ProductSales).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }