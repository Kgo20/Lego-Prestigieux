using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lego_Prestigieux.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ProductModel> Produits { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<CommandModel> Commands { get; set; }
        public DbSet<CartItemModel> CartItems { get; set; }
        public DbSet<BillingModel> Billings { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

        }

    }
}
