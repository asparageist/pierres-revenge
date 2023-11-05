using Microsoft.AspNetCore.Mvc;
using Revenge.Models;
using System.Linq;

namespace Revenge.Controllers
{
  public class HomeController : Controller
  {
    private readonly RevengeContext _db;

    public HomeController(RevengeContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.Treats = _db.Treats.ToList();
      ViewBag.Flavors = _db.Flavors.ToList();
      return View();
    }

  }
}