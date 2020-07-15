using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace LocalData
{
  public class DbContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public DbSet<Book> Companies { get; set; }
    
    public DbSet<Chapter> Phones { get; set; }
     
    public DbContext()
    {
      Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Filename=Mobile.db");
    }
  }
}