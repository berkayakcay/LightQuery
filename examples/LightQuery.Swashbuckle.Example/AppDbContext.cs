using LightQuery.Swashbuckle.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace LightQuery.Swashbuckle.Example
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}