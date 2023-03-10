using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using HairSalon.Models;

namespace HairSalon.Controllers;

public class StylistsController : Controller
{
  private readonly HairSalonContext _db;

  public StylistsController(HairSalonContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Stylist> model = _db.Stylists.ToList();
    return View(model);
  }

  public ActionResult Create()
  {
    ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Name");
    return View();
  }

  [HttpPost]
  public ActionResult Create(Stylist Stylist)
  {
    Stylist.Status = "Active";
    _db.Stylists.Add(Stylist);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    Stylist thisStylist = _db.Stylists
                            .Include(stylist => stylist.Appointments)
                            .FirstOrDefault(stylist => stylist.StylistId == id);
    return View(thisStylist);
  }
}