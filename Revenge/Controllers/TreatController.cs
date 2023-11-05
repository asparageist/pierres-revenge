// using Microsoft.AspNetCore.Mvc;
// using Revenge.Models;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using System.Security.Principal;
// using Microsoft.AspNetCore.Authorization;

// namespace Revenge.Controllers
// {
//   [Authorize]
//   public class CuisineController : Controller
//   {
//     private readonly RevengeContext _db;

//     public TreatController(RevengeContext db)
//     {
//       _db = db;
//     }

//     public ActionResult Index()
//     {
//       ViewBag.PageTitle = "All Cuisines";
//       return View(_db.Cuisines.ToList());
//     }

//     public ActionResult New()
//     {
//       ViewBag.PageTitle = "Add a Treat";
//       return View();
//     }

//     [HttpPost]
//     public ActionResult New(Treat treat)
//     {
//       _db.Treat.Add(treat);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Details(int id)
//     {
//       Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatID == id);
//       return View(thisTreat);
//     }

//     public ActionResult Edit(int id)
//     {
//       Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatID == id);
//       return View(thisTreat);
//     }

//     [HttpPost]
//     public ActionResult Edit(Treat treat)
//     {
//       _db.Treats.Update(treat);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Delete(int id)
//     {
//       Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatID == id);
//       return View(thisTreat);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatID == id);
//       _db.Treats.Remove(thisTreat);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//   }

// }