using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        // Fallback for design-time commands if no appsettings are loaded
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AspNet8JwtDb;Trusted_Connection=True;Encrypt=False");
        return new AppDbContext(optionsBuilder.Options);
    }
}