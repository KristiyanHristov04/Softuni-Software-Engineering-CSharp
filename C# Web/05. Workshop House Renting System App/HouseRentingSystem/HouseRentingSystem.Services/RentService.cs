using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Interfaces;
using HouseRentingSystem.ViewModels.House;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services
{
    public class RentService : IRentService
    {
        private readonly HouseRentingDbContext context;
        public RentService(HouseRentingDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<RentViewModel>> AllRentedHousesAsync()
        {
            List<RentViewModel> allRents = new List<RentViewModel>();

            var allRentedHouses = await this.context.Houses
                .Include(h => h.Agent)
                .ThenInclude(a => a.User)
                .Where(h => h.RenterId != null)
                .ToListAsync();

            foreach (var h in allRentedHouses)
            {
                var currentUser = await this.context.Users.FirstAsync(u => u.Id == h.RenterId);

                RentViewModel rentViewModel = new RentViewModel()
                {
                    HouseTitle = h.Title,
                    HouseImageUrl = h.ImageUrl,
                    AgentFullName = h.Agent.User.FirstName + " " + h.Agent.User.LastName,
                    AgentEmail = h.Agent.User.Email,
                    RenterFullName = currentUser.FirstName + " " + currentUser.LastName,
                    RenterEmail = currentUser.Email
                };

                allRents.Add(rentViewModel);
            }

            return allRents;
        }
    }
}
