using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Revenge.Models
{
  public class Flavor
  {
    public int FlavorID { get; set; }
    [Required(ErrorMessage = "what this flavor is")]
    public string FlavorName { get; set; }
    public List<Treat> Treat { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
    // public ApplicationUser User { get; set; }
  }
}