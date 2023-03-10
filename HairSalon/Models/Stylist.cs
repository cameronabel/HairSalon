using System;

namespace HairSalon.Models;

public class Stylist
{
  public int StylistId { get; set; }
  public string Name { get; set; }
  public DateTime? HireDate { get; set; }
  public DateTime? TerminationDate { get; set; }
  public DateTime? RehireDate { get; set; }
  public string Status { get; set; }
  public Specialty Specialty { get; set; }
  public int SpecialtyId { get; set; }
  public List<Appointment> Appointments { get; set; }
}