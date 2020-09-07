using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace EmpManagement.Controllers
{
    [Authorize(Roles = "Manager,Technical,Sales")]
    [Route("invoice")]
    public class InvoiceController : Controller
    {
        public AppDbContext db;
        public InvoiceController(AppDbContext _db )
        {
            db = _db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            List<AltProject> project = db.AltProject.ToList();
            List<Sales> sales = db.Sales.ToList();

            List<ProductSales> ProductSales = db.ProductSales.ToList();
            var MainRecord = from ps in ProductSales
                             join s in sales on ps.Sales_Id equals s.Id into table1
                             from s in table1.ToList()
                             join p in project on ps.Project_Id equals p.Id into table2
                             from p in table2.ToList()
                             select new ViewModel
                             {
                                 ProductSales = ps,
                                 sales = s,
                                 project = p
                             };
            return View(MainRecord);
        }
        [Route("newindex")]
        public IActionResult NewIndex(){

            List<AltProject> project = db.AltProject.ToList();
            List<Client> client = db.Client.ToList();

            List<ProjectClient> ProjectClient = db.ProjectClient.ToList();
            var MainRecord = from pc in ProjectClient
                             join c in client on pc.Client_Id equals c.Id into table1
                             from c in table1.ToList()
                             join p in project on pc.Project_Id equals p.Id into table2
                             from p in table2.ToList()
                             select new ViewModel
                             {
                                 ProjectClient = pc,
                                 client = c,
                                 project = p
                             };
            return View(MainRecord);

        }
        [Route("newnextindex")]
        public IActionResult NewNextIndex()
        {

            List<RentedFromClients> rented = db.RentedFromClients.ToList();
            List<Client> client = db.Client.ToList();

            List<ProductClient> ProductClient = db.ProductClient.ToList();
            var MainRecord = from pcs in ProductClient
                             join c in client on pcs.Client_Id equals c.Id into table1
                             from c in table1.ToList()
                             join r in rented on pcs.RentedFromClients_Id equals r.Id into table2
                             from r in table2.ToList()
                             select new ViewModel
                             {
                                 ProductClient = pcs,
                                 client = c,
                                 rented = r
                             };
            return View(MainRecord);

        }
        [Route("newnextnextindex")]
        public IActionResult NewNextNextIndex()
        {
            List<Coast> Coast = db.Coast.ToList();
            List<CoastStatus> CoastStatus = db.CoastStatus.ToList();

            var MainRecord = from e in Coast
                             join s in CoastStatus on e.Id equals s.Status_Id into table1
                             from s in table1.ToList()
                             select new ViewModel
                             {
                                 Coast = e,
                                 CoastStatus = s
                             };

            return View(MainRecord);

        }
    }
}