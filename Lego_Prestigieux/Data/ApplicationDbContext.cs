using Lego_Prestigieux.Models;
using Microsoft.EntityFrameworkCore;

namespace Lego_Prestigieux.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produit> Produits { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
