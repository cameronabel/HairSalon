using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using HairSalon.Models;

namespace HairSalon.Controllers;

public class ClientsController : Controller
{
  private readonly HairSalonContext _db;

  public ClientsController(HairSalonContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Client> model = _db.Clients.ToList();
    return View(model);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Client client)
  {
    _db.Clients.Add(client);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  [HttpPost]
  public ActionResult CreateFromAppt(string name, string phone, string email)
  {

    Client newClient = new Client();
    newClient.Name = name;
    newClient.Phone = phone;
    newClient.Email = email;
    _db.Clients.Add(newClient);
    _db.SaveChanges();
    return RedirectToAction("Create", "Appointments");
  }

  public ActionResult GetClient(int id)
  {
    Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
    return Json($"{{\"Name\": \"{thisClient.Name}\", \"Phone\": \"{thisClient.Phone}\", \"Email\": \"{thisClient.Email}\"}}");
  }

  public ActionResult Details(int id)
  {
    Client thisClient = _db.Clients
                            .Include(client => client.Appointments)
                            .FirstOrDefault(client => client.ClientId == id);
    return View(thisClient);
  }

}