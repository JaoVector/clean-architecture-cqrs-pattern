using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FollowMe.Persistence.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FollowMe;Trusted_Connection=True;Encrypt=false");

            return new AppDbContext(options.Options);
        }
    }
}
