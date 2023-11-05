// using Microsoft.AspNetCore.Mvc;
// using Revenge.Models;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore.Metadata.Internal;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using System.Threading.Tasks;
// using System.Security.Claims;

// namespace Revenge.Controllers
// {
//   [Authorize]
//   public class RevengeController : Controller
//   {
//     private readonly RevengeContext _db;
//     private readonly UserManager<ApplicationUser> _userManager;

//     public RevengeController(UserManager<ApplicationUser> userManager, RevengeContext db)
//     {
//       _userManager = userManager;
//       _db = db;
//     }

//     public async Task<ActionResult> Index()
//     {
//       string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//       ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
//       List<Flavor> userFlavors = _db.Flavors
//                           .Where(entry => entry.User.Id == currentUser.Id)
//                           .Include(flavor => flavor.Flavors)
//                           .ToList();
//       return View(userFlavors);
//     }

//     [HttpPost]
//     public async Task<ActionResult> New(Flavor flavor, int TreatID)
//     {
//       if (!ModelState.IsValid)
//       {
//         ViewBag.TreatID = new SelectList(_db.Treats, "TreatID", "Name");
//         return View(flavor);
//       }
//       else
//       {
//         string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//         ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
//         flavor.User = currentUser;
//         _db.userFlavors.Add(flavor);
//         _db.SaveChanges();
//         return RedirectToAction("Index");
//       }
//     }

//     public ActionResult New()
//     {
//       ViewBag.PageTitle = "Add a Flavor";
//       return View();
//     }

//     public ActionResult Details(int id)
//     {
//       Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorID == id);
//       return View(thisFlavor);
//     }

//     public ActionResult Edit(int id)
//     {
//       Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorID == id);
//       return View(thisFlavor);
//     }

//     [HttpPost]
//     public ActionResult Edit(Flavor flavor)
//     {
//       _db.Recipes.Update(flavor);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//     public ActionResult Delete(int id)
//     {
//       Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorID == id);
//       return View(thisFlavor);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorID == id);
//       _db.Flavors.Remove(thisFlavor);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }

//   }
// }