using HouseRentingSystem.Data;
using HouseRentingSystem.Services;
using HouseRentingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
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
              .AddEntityFrameworkStores<HouseRentingDbContext>();

            builder.Services.AddTransient<IHouseService, HouseService>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}