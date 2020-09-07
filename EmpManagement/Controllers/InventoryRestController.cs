using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpManagement.Controllers
{

    [Authorize(Roles = "Manager,Technical,Sales")]

    [Route("api/inventory")]
    public class InventoryRestController : ControllerBase
    {
        private AppDbContext db;
        public InventoryRestController(AppDbContext _db)
        {
            db = _db;



        }
        [HttpGet("findall")]
        [Produces("application/json")]
        public async Task<IActionResult> findAll()
        {
            try
            {
                var productModel1 = (db.Inventory.Select(
                    e => new
                    {
                        id = e.Id,
                        name = e.Name,
                        price = e.Price,
                        quantity = e.Quantity
                    }).ToList());
                return Ok(productModel1);
            }
            catch
            {
                return BadRequest();

            }


        }
    } 

    }