using TasalHousing.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TasalHousing.Data.DatabaseContexts.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Property> Properties { get; set }

        public DbSet<Contacts> Contacts { get; set }
    }
}