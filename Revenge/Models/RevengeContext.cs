using Microsoft.EntityFrameworkCore;

namespace Revenge.Models
{
  public class RevengeContext : DbContext
  {
    public DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<FlavorTreat> FlavorTreats { get; set; }
    public RevengeContext(DbContextOptions options) : base(options) { }
  }
}