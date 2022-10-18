using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lego_Prestigieux.Data
{
    public static class SeedExtension
    {
        private static readonly PasswordHasher<ApplicationUser> PASSWORD_HASHER = new();

        private static ProductModel ProductSeed(string name, string detail, int price, int reduction, int quantity, Status status, Category category, string url)
        {
            var product = new ProductModel
            {
                Name = name,
                Detail = detail,
                Price = price,
                Reduction = reduction,
                Quantity = quantity,
                Status = status,
                Category = category,
                URL = url
            };

            return product;
        }

        public static void Seed(this ModelBuilder builder)
        {
            var admins = new List<ApplicationUser>() {
                CreateUser("Francois", "Qwerty123!")
            };

            var products = new List<ProductModel>()
            {

            };

            builder.SeedUsers(admins);
            builder.SeedUsersToRole(admins, new IdentityRole("Admin"));
        }

        private static ApplicationUser CreateUser(string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
            };
            user.PasswordHash = PASSWORD_HASHER.HashPassword(user, password);

            return user;
        }

        private static void SeedUsers(this ModelBuilder builder, IEnumerable<ApplicationUser> users)
        {
            foreach (var user in users)
            {
                builder.Entity<ApplicationUser>().HasData(user);
            }
        }

        private static void SeedUsersToRole(this ModelBuilder builder, IEnumerable<ApplicationUser> users, IdentityRole role)
        {
            builder.Entity<IdentityRole>().HasData(role);

            foreach (var user in users)
            {
                builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = role.Id
                });
            }
        }
    }
}
