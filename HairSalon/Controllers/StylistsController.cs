using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

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
                            .Include(stylist => stylist.Specialty)
                            .FirstOrDefault(stylist => stylist.StylistId == id);
    return View(thisStylist);
  }

  public ActionResult Edit(int id)
  {
    Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
    ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Name", thisStylist.SpecialtyId);

    return View(thisStylist);
  }

  [HttpPost]
  public ActionResult Edit(int id, string name, DateTime hireDate, DateTime terminationDate, DateTime rehireDate, int specialtyId)
  {
    DateTime nullDate = new DateTime(0);
    Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
    thisStylist.Name = name;
    if (hireDate != nullDate)
    {
      thisStylist.HireDate = hireDate;
    }
    if (terminationDate != nullDate)
    {
      thisStylist.TerminationDate = terminationDate;
    }
    if (rehireDate != nullDate)
    {
      thisStylist.RehireDate = rehireDate;
    }
    if (thisStylist.TerminationDate.HasValue)
    {
      if (thisStylist.RehireDate.HasValue)
      {
        if (thisStylist.RehireDate > thisStylist.TerminationDate)
        {
          thisStylist.Status = "Active";
        }
        else
        {
          thisStylist.Status = "Inactive";
        }
      }
      else
      {
        thisStylist.Status = "Inactive";
      }
    }

    thisStylist.SpecialtyId = specialtyId;
    _db.Stylists.Update(thisStylist);
    _db.SaveChanges();
    return RedirectToAction("Details", new { id = id });
  }

  public ActionResult Delete(int id)
  {
    Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
    return View(thisStylist);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
    _db.Stylists.Remove(thisStylist);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult GetApplicableStylists(int id)
  {
    Console.WriteLine("HEREHERE");
    Console.WriteLine(id);
    List<Stylist> stylists = _db.Stylists.ToList().Where(stylist => stylist.SpecialtyId == id).ToList();
    var json = JsonSerializer.Serialize(stylists);
    return Json(json);
  }
}