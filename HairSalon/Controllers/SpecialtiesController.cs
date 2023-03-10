using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using HairSalon.Models;

namespace HairSalon.Controllers;

public class SpecialtiesController : Controller
{
  private readonly HairSalonContext _db;

  public SpecialtiesController(HairSalonContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Specialty> model = _db.Specialties.ToList();
    return View(model);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Specialty specialty)
  {
    _db.Specialties.Add(specialty);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult CreateFromAppt(string name)
  {
    Specialty newSpecialty = new Specialty();
    newSpecialty.Name = name;
    _db.Specialties.Add(newSpecialty);
    _db.SaveChanges();
    return RedirectToAction("Create", "Appointments");
  }
}