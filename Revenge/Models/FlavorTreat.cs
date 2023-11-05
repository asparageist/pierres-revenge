namespace Revenge.Models
{
  public class FlavorTreat
  {
    public int FlavorTreatID { get; set; }
    public int FlavorID { get; set; }
    public Flavor Flavor { get; set; }
    public int TreatID { get; set; }
    public Treat Treat { get; set; }
  }
}