using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.ViewModels.House
{
    public class RentViewModel
    {
        public string HouseTitle { get; set; } = null!;
        public string HouseImageUrl { get; set; } = null!;
        public string AgentFullName { get; set; } = null!;
        public string AgentEmail { get; set; } = null!;
        public string RenterFullName { get; set; } = null!;
        public string RenterEmail { get; set; } = null!;
    }
}
