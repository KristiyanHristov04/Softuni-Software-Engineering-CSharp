using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Interfaces;
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
        public ApplicationUserService(HouseRentingDbContext _context)
        {
            this.context = _context;
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            var user = await this.context.Users.FindAsync(userId);

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }
    }
}
