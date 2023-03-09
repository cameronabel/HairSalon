using System;

namespace HairSalon.Models;

public class Stylist
{
  public int StylistId { get; set; }
  public string Name { get; set; }
  public DateOnly HireDate { get; set; }
  public DateOnly TerminationDate { get; set; }
  public DateOnly RehireDate { get; set; }
  public string Status { get; set; }
  public Specialty Specialty { get; set; }
  public int SpecialtyId { get; set; }
}