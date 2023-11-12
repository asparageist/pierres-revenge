using Microsoft.AspNetCore.Mvc;
using Revenge.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;


namespace Revenge.Controllers
{

  public class TreatController : Controller
  {
    private readonly RevengeContext _db;

    public TreatController(RevengeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "All Treats";
      return View(_db.Treats.ToList());
    }

    [Authorize]
    public ActionResult New()
    {
      ViewBag.PageTitle = "Add a Treat";
      return View();
    }

    [HttpPost]
    public ActionResult New(Treat treat)
    {
      if (!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
        {
          _db.Treats.Add(treat);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
    }

    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
          .Include(treat => treat.JoinEntities)
          .ThenInclude(join => join.Flavor)
          .FirstOrDefault(treat => treat.TreatID == id);
      return View(thisTreat);
    }

    [Authorize]
    public ActionResult AddFlavor(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatID == id);
      ViewBag.FlavorID = new SelectList(_db.Flavors, "FlavorID", "FlavorName");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int flavorID)
    {
#nullable enable
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.FlavorID == flavorID && join.TreatID == treat.TreatID));
#nullable disable
      if (joinEntity == null && flavorID != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { FlavorID = flavorID, TreatID = treat.TreatID });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = treat.TreatID });
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatID == id);
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatID == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatID == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult RemoveFlavor(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatID == id);
      var onlyFlavorIDs = _db.FlavorTreats
                              .Where(em => em.TreatID == id)
                              .Select(em => em.FlavorID)
                              .ToList();

      var onlyFlavors = _db.Flavors
                              .Where(m => onlyFlavorIDs.Contains(m.FlavorID))
                              .ToList();

      ViewBag.FlavorID = new SelectList(onlyFlavors, "FlavorID", "FlavorName");
      return View(thisTreat);
    }


    [HttpPost]
    public ActionResult RemoveFlavor(Treat treat, int flavorID)
    {
      FlavorTreat joinEntity = _db.FlavorTreats
          .FirstOrDefault(join => join.FlavorID == flavorID && join.TreatID == treat.TreatID);

      if (joinEntity != null)
      {
        _db.FlavorTreats.Remove(joinEntity);
        _db.SaveChanges();
      }

      return RedirectToAction("Details", new { id = treat.TreatID });
    }

  }
}