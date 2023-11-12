using Microsoft.AspNetCore.Mvc;
using Revenge.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Revenge.Controllers
{
  public class FlavorController : Controller
  {
    private readonly RevengeContext _db;

    public FlavorController(RevengeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "All Flavors";
      return View(_db.Flavors.ToList());
    }

    public ActionResult New()
    {
      ViewBag.PageTitle = "Add a Flavor";
      return View();
    }

    [HttpPost]
    public ActionResult New(Flavor flavor)
    {
      if (!ModelState.IsValid)
      {
        return View(flavor);
      }
      else

      {
        _db.Flavors.Add(flavor);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
    public ActionResult Details(int id)
    {
      Flavor thisFlavor = _db.Flavors
          .Include(flavor => flavor.JoinEntities)
          .ThenInclude(join => join.Treat)
          .FirstOrDefault(flavor => flavor.FlavorID == id);
      return View(thisFlavor);
    }

    public ActionResult AddTreat(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorID == id);
      ViewBag.TreatID = new SelectList(_db.Treats, "TreatID", "TreatName");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int treatID)
    {
#nullable enable
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.TreatID == treatID && join.FlavorID == flavor.FlavorID));
#nullable disable
      if (joinEntity == null && treatID != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { TreatID = treatID, FlavorID = flavor.FlavorID });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = flavor.FlavorID });
    }


    public ActionResult Edit(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorID == id);
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorID == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorID == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult RemoveTreat(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorID == id);
      var onlyTreatIDs = _db.FlavorTreats
                              .Where(em => em.FlavorID == id)
                              .Select(em => em.TreatID)
                              .ToList();

      var onlyTreats = _db.Treats
                              .Where(m => onlyTreatIDs.Contains(m.TreatID))
                              .ToList();

      ViewBag.TreatID = new SelectList(onlyTreats, "TreatID", "TreatName");
      return View(thisFlavor);
    }


    [HttpPost]
    public ActionResult RemoveTreat(Flavor flavor, int treatID)
    {
      FlavorTreat joinEntity = _db.FlavorTreats
          .FirstOrDefault(join => join.TreatID == treatID && join.FlavorID == flavor.FlavorID);

      if (joinEntity != null)
      {
        _db.FlavorTreats.Remove(joinEntity);
        _db.SaveChanges();
      }

      return RedirectToAction("Details", new { id = flavor.FlavorID });
    }

  }
}