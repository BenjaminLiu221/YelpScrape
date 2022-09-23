using Microsoft.EntityFrameworkCore;
using YelpScrapeWeb.Models;

namespace YelpScrapeWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Authorization> Authorizations { get; set; }
    }
}
