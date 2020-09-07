using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace EmpManagement.Controllers
{
    [Authorize(Roles = "Manager,Technical,Sales")]
    public class ProjectsController : Controller
    {
        public AppDbContext db;

        public ProjectsController(AppDbContext _db)
        {
            db = _db;
        }
        // GET: Projects
        public IActionResult Index()
        {
            return View(db.Projects.ToList());
        }
        // GET: Projects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
            }

            Project Project = await db.Projects.Include(p => p.Products).SingleAsync(m => m.Id == id);
            if (Project == null)
            {
            }
            SelectUsedProducts(Project);
            return View(Project);
        }
        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewBag.ActionType = "Create";
            EnsureMandatoryProducts();
            var Project = new Project
            {
            };
            SelectAllProducts(Project);
            return View("CreateEdit", Project);
        }

        public IActionResult Search(string query)
        {
            return View("Index", db.Projects.Where(Project => Project.Name.StartsWith(query)));
        }

        protected virtual void EnsureMandatoryProducts()
        {
            if (db.Products.Count(ig => MandatoryProducts.Products.Contains(ig.Name)) != MandatoryProducts.Products.Length)
            {
                MandatoryProducts.Products.ToList().ForEach(mi =>
                {
                    try
                    {
                        db.Products.Add(new Product { Name = mi });
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        //seed only
                    }
                });
            }
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project Project)
        {
            ViewBag.ActionType = "Create";
            ValidateName(Project);
            if (ModelState.IsValid)
            {
                if (!db.Projects.Any(p => p.Name == Project.Name))
                {
                    await AddProject(Project);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Taka Project już istnieje");
                }

            }
            SelectAllProducts(Project);
            return View("CreateEdit", Project);
        }

        protected virtual void ValidateName(Project Project)
        {
            Project.Name = (Project.Name ?? "").Trim();
            if (string.IsNullOrEmpty(Project.Name))
            {
                ModelState.AddModelError("", "Nazwa pizzy nie może być pusta!");
            }
        }

        protected virtual void SelectAllProducts(Project Project)
        {
            Project.UsedProducts =
                db.Products.ToArray()
                    .ToDictionary(ig => ig.Name, ig => MandatoryProducts.Products.Contains(ig.Name) || (Project.UsedProducts != null && Project.UsedProducts.ContainsKey(ig.Name)));
        }

        protected virtual async Task AddProject(Project Project)
        {
            Project.Id = Guid.NewGuid();
            db.Projects.Add(Project);
            AddProjectProducts(Project);
            await db.SaveChangesAsync();
        }

        protected virtual void AddProjectProducts(Project Project)
        {
            var Products = new List<Product>();
            MandatoryProducts.Products.ToList()
                .ForEach(igr => Products.Add(db.Products.FirstOrDefault(ingr => ingr.Name == igr)));
            Project.UsedProducts.Where(igr => !MandatoryProducts.Products.Contains(igr.Key)).ToList().ForEach(ingr =>
            {
                if (ingr.Value)
                {
                    Products.Add(db.Products.FirstOrDefault(i => i.Name == ingr.Key));
                }
            });

            Products.Select(ingr => new ProjectProduct { ProductId = ingr.Id, ProjectId = Project.Id })
                .ToList()
                .ForEach(ingr => db.ProjectProducts.Add(ingr));
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            ViewBag.ActionType = "Edit";
            if (id == null)
            {
            }

            var Project = await db.Projects.Include(p => p.Products).SingleAsync(m => m.Id == id);
            if (Project == null)
            {
            }
            SelectUsedProducts(Project);
            return View("CreateEdit", Project);
        }

        protected virtual void SelectUsedProducts(Project Project)
        {
            Project.UsedProducts = db.Products.ToArray()
                .ToDictionary(igr => igr.Name, igr => Project.Products.Any(i => i.ProductId == igr.Id));
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Project Project)
        {
            ViewBag.ActionType = "Edit";
            ValidateName(Project);
            if (ModelState.IsValid)
            {
                db.ProjectProducts.Where(pi => pi.ProjectId == Project.Id).ToList().ForEach(pi => db.ProjectProducts.Remove(pi));
                await db.SaveChangesAsync();
                AddProjectProducts(Project);
                db.Update(Project);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            Project.UsedProducts = db.Products.ToArray().ToDictionary(igr => igr.Name, igr => db.Projects.Include(p => p.Products).Single(p => p.Id == Project.Id).Products.Any(i => i.ProductId == igr.Id));
            return View("CreateEdit", Project);
        }

        // GET: Projects/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
            }

            Project Project = await db.Projects.Include(p => p.Products).SingleAsync(m => m.Id == id);
            if (Project == null)
            {
            }
            SelectUsedProducts(Project);
            return View(Project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Project Project = await db.Projects.SingleAsync(m => m.Id == id);
            db.Projects.Remove(Project);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
