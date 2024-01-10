using Microsoft.EntityFrameworkCore;
using WebApp.Data.Model;

namespace WebApp.Data.Model
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Logic> Credits { get; set; }

    }
}
