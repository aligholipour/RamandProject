using Microsoft.AspNetCore.Identity;
using Ramand.Domain.Entities;
using Ramand.Infrastructure.Persistence;

namespace Ramand.Api.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
