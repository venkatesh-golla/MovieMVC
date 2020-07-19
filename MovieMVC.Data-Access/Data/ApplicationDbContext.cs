using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieMVC.Model;

namespace MovieMVC.Data_Access.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
