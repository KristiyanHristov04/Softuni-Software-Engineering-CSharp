using HouseRentingSystem.ViewModels.House;

namespace HouseRentingSystem.Areas.Admin.Models
{
    public class MyHousesViewModel
    {
        public IEnumerable<HouseViewModel> AddedHouses { get; set; }
            = new List<HouseViewModel>();
        public IEnumerable<HouseViewModel> RentedHouses { get; set; }
            = new List<HouseViewModel>();
    }
}
