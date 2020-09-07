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
    [Route("kanbanviewsales")]
    public class KanbanViewSalesController : Controller
    {
        public AppDbContext db;
        public KanbanViewSalesController(AppDbContext _db)
        {
            db = _db;

        }
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.Evaluation = db.Evaluation.ToList();
            ViewBag.Negotiation = db.Negotiation.ToList();
            ViewBag.Contract = db.Contract.ToList();
            
            ViewBag.ClosedWon = db.ClosedWon.ToList();
            ViewBag.ClosedLost = db.ClosedLost.ToList();
            ViewBag.Sales = db.Sales.ToList();

            return View();
        }

        [HttpGet]
        [Route("arrowaceone/{id}")]
        public IActionResult ArrowAceOne(int id)
        {
            var str = db.Evaluation.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "ClosedLost";
                ClosedLost ls = new ClosedLost();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.ClosedLost.Add(ls);

            }
            db.SaveChanges();
            db.Evaluation.Remove(db.Evaluation.Find(id));

            db.SaveChanges();
           
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowacetwo/{id}")]
        public IActionResult ArrowAceTwo(int id)
        {
            var str = db.Evaluation.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "Negotiation";
                Negotiation ls = new Negotiation();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.Negotiation.Add(ls);

            }
            db.SaveChanges();
            db.Evaluation.Remove(db.Evaluation.Find(id));

            db.SaveChanges();
          
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowacethree/{id}")]
        public IActionResult ArrowAceThree(int id)
        {
            var str = db.Negotiation.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "Evaluation";
                Evaluation ls = new Evaluation();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.Evaluation.Add(ls);

            }
            db.SaveChanges();
            db.Negotiation.Remove(db.Negotiation.Find(id));

            db.SaveChanges();
           
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowacefour/{id}")]
        public IActionResult ArrowAceFour(int id)
        {
            var str = db.Negotiation.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "Contract";
                Contract ls = new Contract();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.Contract.Add(ls);

            }
            db.SaveChanges();
            db.Negotiation.Remove(db.Negotiation.Find(id));

            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowacefive/{id}")]
        public IActionResult ArrowAceFive(int id)
        {
            var str = db.Contract.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "Negotiation";
                Negotiation ls = new Negotiation();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.Negotiation.Add(ls);

            }
            db.SaveChanges();
            db.Contract.Remove(db.Contract.Find(id));

            db.SaveChanges();
         
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowacesix/{id}")]
        public IActionResult ArrowAceSix(int id)
        {
            var str = db.Contract.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "ClosedWon";
                ClosedWon ls = new ClosedWon();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.ClosedWon.Add(ls);

            }
            db.SaveChanges();
            db.Contract.Remove(db.Contract.Find(id));

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowaceseven/{id}")]
        public IActionResult ArrowAceSeven(int id)
        {
            var str = db.ClosedWon.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "Contract";
                Contract ls = new Contract();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.Contract.Add(ls);

            }
            db.SaveChanges();
            db.ClosedWon.Remove(db.ClosedWon.Find(id));

            db.SaveChanges();
           /* var cat = db.Contract.Where(x => x.Id == id).ToList();
            foreach (var car in cat) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "Contract";
                int xd = car.Id ;
                Sales ls = new Sales();
                ls.Id = xd;
                ls.Name = car.Name;
                ls.Rep = car.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = car.Priority;
                ls.ExpectedCloseDate = car.ExpectedCloseDate;
                ls.ForeCastValue = car.ForeCastValue;
                ls.Probability = car.Probability;
                ls.LastContact = car.LastContact;
                ls.SignedContractValue = car.SignedContractValue;
                ls.Notes = car.Notes;




                db.Sales.Add(ls);

            }
            db.SaveChanges();
            db.Sales.Remove(db.Sales.Find(id+100));
            db.SaveChanges();
            */
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowaceeight/{id}")]
        public IActionResult ArrowAceEight(int id)
        {
            var str = db.ClosedWon.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "ClosedLost";
                ClosedLost ls = new ClosedLost();
                ls.Id = val.Id+100;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.ClosedLost.Add(ls);

            }
            db.SaveChanges();
            db.ClosedWon.Remove(db.ClosedWon.Find(id));

            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowacenine/{id}")]
        public IActionResult ArrowAceNine(int id)
        {
            var str = db.ClosedLost.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "ClosedWon";
                ClosedWon ls = new ClosedWon();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.ClosedWon.Add(ls);

            }
            db.SaveChanges();
            db.ClosedLost.Remove(db.ClosedLost.Find(id));

            db.SaveChanges();
           
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("arrowaceten/{id}")]
        public IActionResult ArrowAceTen(int id)
        {
            var str = db.ClosedLost.Where(x => x.Id == id).ToList();
            foreach (var val in str) // iterator the data from the list and insert them into the listSecond
            {
                string SalesStage = "Evaluation";
                Evaluation ls = new Evaluation();
                ls.Id = val.Id;
                ls.Name = val.Name;
                ls.Rep = val.Rep;
                ls.SalesStage = SalesStage;
                ls.Priority = val.Priority;
                ls.ExpectedCloseDate = val.ExpectedCloseDate;
                ls.ForeCastValue = val.ForeCastValue;
                ls.Probability = val.Probability;
                ls.LastContact = val.LastContact;
                ls.SignedContractValue = val.SignedContractValue;
                ls.Notes = val.Notes;




                db.Evaluation.Add(ls);

            }
            db.SaveChanges();
            db.ClosedLost.Remove(db.ClosedLost.Find(id));

            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}