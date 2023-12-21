
using HouseRentingSystem.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HouseRentingSystem.Common.DataConstants.AdminUser;

namespace HouseRentingSystem.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider services = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRole))
                {
                    return;
                }

                IdentityRole role = new IdentityRole(AdminRole);

                await roleManager.CreateAsync(role);

                ApplicationUser admin = await userManager.FindByNameAsync(AdminEmail);

                await userManager.AddToRoleAsync(admin, role.Name);
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
