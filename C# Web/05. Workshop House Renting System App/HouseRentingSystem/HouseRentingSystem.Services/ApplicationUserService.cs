using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.ApplicationUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly HouseRentingDbContext context;
        public ApplicationUserService(
            HouseRentingDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            List<UserViewModel> allUsers = new List<UserViewModel>();

            var agents = await context.Agents
                .Include(ag => ag.User)
                .ToListAsync();

            foreach (var agent in agents)
            {
                UserViewModel user = new UserViewModel
                {
                    Email = agent.User.Email,
                    FullName = await UserFullNameAsync(agent.User.Id),
                    PhoneNumber = agent.User.PhoneNumber
                };

                allUsers.Add(user);
            }

            var users = await context.Users
                .Where(u => !this.context.Agents.Any(a => a.UserId == u.Id))
                .ToListAsync();

            foreach (var usr in users)
            {
                var user = new UserViewModel
                {
                    Email = usr.Email,
                    FullName = usr.FirstName + " " + usr.LastName,
                    PhoneNumber = string.Empty
                };

                allUsers.Add(user);
            }

            return allUsers;
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            var user = await this.context.Users.FindAsync(userId);

            if (user == null || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }

        public async Task<bool> UserHasRents(string userId)
        {
            return await this.context.Houses.AnyAsync(h => h.RenterId == userId);
        }
    }
}
