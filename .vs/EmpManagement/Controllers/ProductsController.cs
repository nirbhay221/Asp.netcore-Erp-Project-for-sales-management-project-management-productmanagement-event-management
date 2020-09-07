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
    [Route("products")]
    public class ProductsController : Controller
    {
        protected AppDbContext db;

        public ProductsController(AppDbContext _db)
        {
            db = _db;
        }

        // GET: Products
        [Route("index")]
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }
        [Route("details")]
        // GET: Products/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
            }

            Product Product = db.Products.Single(m => m.Id == id);
            if (Product == null)
            {
            }

            return View(Product);
        }
        // GET: Products/Create

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("Create")]
        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product Product)
        {
            Product.Name = (Product.Name ?? "").Trim();
            if (string.IsNullOrEmpty(Product.Name))
            {
            }

            if (ModelState.IsValid)
            {
                if (!db.Products.Any(igr => igr.Name == Product.Name))
                {
                    Product.Id = Guid.NewGuid();
                    db.Products.Add(Product);
                     db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                }

            }
            return View(Product);
        }
        [Route("edit")]
        // GET: Products/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
            }

            Product Product = db.Products.Single(m => m.Id == id);
            if (Product == null)
            {
            }
            return View(Product);
        }
        [Route("edit")]
        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product Product)
        {
            if (db.Products.Any(igr => igr.Name == Product.Name))
            {
            }

            Product.Name = (Product.Name ?? "").Trim();
            if (string.IsNullOrEmpty(Product.Name))
            {
            }

            if (ModelState.IsValid)
            {
                db.Update(Product);
                 db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Product);
        }
        [Route("Delete")]

        // GET: Products/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(Guid? id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("Deleted")]

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            if (db.ProjectProducts.Any(pi => pi.ProductId == id))
            {
                return RedirectToAction("Delete", new { id = id, error = "yes" });
            }

            var Product = db.Products.Single(m => m.Id == id);
            db.Products.Remove(Product);
     db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}