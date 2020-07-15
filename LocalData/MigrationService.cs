using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LocalData
{
  public class MigrationService
  {
    public async Task Migrate()
    {
      await using var context = new DbContext();
      await context.Database.MigrateAsync();
    }
  }
}