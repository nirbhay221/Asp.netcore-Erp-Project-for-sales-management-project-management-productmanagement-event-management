using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Helpers;
using EmpManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace EmpManagement.Controllers
{

    [Authorize(Roles = "Sales")]
    [Route("cart")]
        public class CartController : Controller
        {
        public AppDbContext db;
            public CartController(AppDbContext _db)
        {
            db = _db;
        }
            [Route("index")]
            public IActionResult Index()
        {
         
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
               ViewBag.total = cart.Sum(i => i.rented.Price * i.Quantity);
                return View();
            }
            [Route("buy/{id}")]
            public IActionResult Buy(int id)
            {
                if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
                {

                    var cart = new List<Item>();
                    cart.Add(new Item() { rented = db.RentedForProject.Find(id), Quantity = 1 });
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                    int index = Exists(cart, id);
                    if (index == -1)
                    {

                        cart.Add(new Item() { rented = db.RentedForProject.Find(id), Quantity = 1 });
                    }
                    else
                    {
                        cart[index].Quantity++;
                    }

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

                }

                return RedirectToAction("Index");
            }
            [Route("remove/{id}")]
            public IActionResult Remove(int id)
            {


                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = Exists(cart, id);
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);



                return RedirectToAction("Index");
            }
            private int Exists(List<Item> cart, int id)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].rented.Id == id)
                    {
                        return i;
                    }

                }
                return -1;

            }
        }
    }