using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services;
using HouseRentingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseRentingSystem.Extensions;

namespace HouseRentingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<HouseRentingDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = builder
                    .Configuration
                    .GetValue<bool>
                    ("IdentityOptions:SignIn:RequireConfirmedAccount");
                options.Password.RequireDigit = builder
                    .Configuration
                    .GetValue<bool>
                    ("IdentityOptions:Password:RequireDigit");
                options.Password.RequireLowercase = builder
                    .Configuration
                    .GetValue<bool>
                    ("IdentityOptions:Password:RequireLowercase");
                options.Password.RequireUppercase = builder
                    .Configuration
                    .GetValue<bool>
                    ("IdentityOptions:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric = builder
                    .Configuration
                    .GetValue<bool>
                    ("IdentityOptions:Password:RequireNonAlphanumeric");
            })
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<HouseRentingDbContext>();

            builder.Services.AddMemoryCache();

            builder.Services.AddTransient<IHouseService, HouseService>();
            builder.Services.AddTransient<IAgentService, AgentService>();
            builder.Services.AddTransient<IStatisticsService, StatisticsService>();
            builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();
            builder.Services.AddTransient<IRentService, RentService>();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "House Details",
                    pattern: "/House/Details/{id}/{information}",
                    defaults: new { Controller = "House", Action = "Details" }
                    );

                app.MapDefaultControllerRoute();
                app.MapRazorPages();
            });

            app.SeedAdmin();

            app.Run();
        }
    }
}