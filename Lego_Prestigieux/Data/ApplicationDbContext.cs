using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lego_Prestigieux.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ProductModel> Produits { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

        }

        public DbSet<Lego_Prestigieux.Models.CreateCustomerWithAddress> CreateCustomerWithAddress { get; set; }

        public DbSet<Lego_Prestigieux.Models.CreateMoreAddress> CreateMoreAddress { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging();
        //}

    }
}
