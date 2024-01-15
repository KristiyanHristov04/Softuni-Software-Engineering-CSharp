using HouseRentingSystem.ViewModels.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<string> UserFullNameAsync (string userId);
        Task<IEnumerable<UserViewModel>> AllAsync();
    }
}
