using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
namespace EmpManagement.Controllers
{ 
    [Route("mainhome")]
    public class MainHomeController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("newindex")]
        public IActionResult NewIndex()
        {
            return View();
        }
    }
}