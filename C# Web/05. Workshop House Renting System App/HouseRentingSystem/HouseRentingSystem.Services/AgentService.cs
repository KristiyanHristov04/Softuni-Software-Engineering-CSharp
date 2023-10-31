using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext context;
        public AgentService(HouseRentingDbContext _context)
        {
            this.context = _context;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            Agent agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await this.context.Agents.AddAsync(agent);
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await this.context.Agents.AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> UserHasRents(string userId)
        {
            return await this.context.Houses.AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await this.context.Agents.AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
