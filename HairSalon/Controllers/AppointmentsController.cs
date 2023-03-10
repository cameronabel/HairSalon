using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

using HairSalon.Models;

namespace HairSalon.Controllers;

public class AppointmentsController : Controller
{
  private readonly HairSalonContext _db;

  public AppointmentsController(HairSalonContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Appointment> model = _db.Appointments.ToList();
    return View(model);
  }

  public ActionResult Create(int id)
  {
    ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name", id);
    ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Name");
    ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
    return View();
  }

  [HttpPost]
  public ActionResult Create(Appointment appointment)
  {
    _db.Appointments.Add(appointment);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
}