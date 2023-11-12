using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revenge.Models
{
  public class Treat
  {
    public int TreatID { get; set; }
    [Required(ErrorMessage = "what this treat is")]
    public string TreatName { get; set; }
    public int Flavor { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
    // public ApplicationUser User { get; set; }
  }
}