using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ramand.Domain.Entities;

namespace Ramand.Infrastructure.Persistence
{
    public static class UserSeedInitializer
    {
        private const string Admin = "Admin";
        private const string Customer = "Customer";

        public static async Task Initialize(this IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            string[] roles = { Admin, Customer };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new Role() { Name = role });
                }
            }

            var users = new[]
            {
                new User { UserName = "admin@example.com", Email = "admin@example.com" },
                new User { UserName = "customer1@example.com", Email = "customer1@example.com" },
                new User { UserName = "customer2@example.com", Email = "customer2@example.com" },
            };

            foreach (var user in users)
            {
                var existUser = await userManager.FindByNameAsync(user.UserName);

                if (existUser is null)
                {
                    var result = await userManager.CreateAsync(user, "Ramand123");

                    if (result.Succeeded)
                    {
                        // Assign roles to users
                        if (user.UserName == "admin@example.com")
                        {
                            await userManager.AddToRoleAsync(user, Admin);
                        }
                        else
                        {
                            await userManager.AddToRoleAsync(user, Customer);
                        }
                    }
                }
            }
        }
    }
}
