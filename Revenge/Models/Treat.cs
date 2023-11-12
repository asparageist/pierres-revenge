using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Revenge.Models
{
  public class Treat
  {
    public int TreatID { get; set; }
    [Required(ErrorMessage = " eyy, what this treat is, fool? ")]
    public string TreatName { get; set; }
    public int Flavor { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
    // public ApplicationUser User { get; set; }
  }
}