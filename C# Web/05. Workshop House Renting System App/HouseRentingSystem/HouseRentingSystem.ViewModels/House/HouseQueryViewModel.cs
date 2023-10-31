using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.ViewModels.House
{
    public class HouseQueryViewModel
    {
        public int TotalHousesCount { get; set; }
        public IEnumerable<HouseViewModel> Houses { get; set; } = new List<HouseViewModel>();
    }
}
