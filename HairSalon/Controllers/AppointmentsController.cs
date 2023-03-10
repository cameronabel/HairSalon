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

  public ActionResult Details(int id)
  {
    Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
    ViewBag.Client = _db.Clients.FirstOrDefault(client => client.ClientId == thisAppointment.ClientId);
    ViewBag.Stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == thisAppointment.StylistId);
    ViewBag.Specialty = _db.Stylists.FirstOrDefault(specialty => specialty.SpecialtyId == thisAppointment.SpecialtyId);
    return View(thisAppointment);
  }

  public ActionResult Create(int id)
  {
    ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name", id);
    ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Name");
    ViewBag.StylistId = new SelectList(_db.Stylists.Where(stylist => stylist.Status == "ACTIVE"), "StylistId", "Name");
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