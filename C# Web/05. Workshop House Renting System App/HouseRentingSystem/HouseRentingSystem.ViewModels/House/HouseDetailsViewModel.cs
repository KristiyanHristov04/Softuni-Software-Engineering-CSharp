using HouseRentingSystem.ViewModels.Agent;

namespace HouseRentingSystem.ViewModels.House
{
    public class HouseDetailsViewModel : HouseViewModel
    {
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public AgentViewModel Agent { get; set; } = null!;
    }
}
