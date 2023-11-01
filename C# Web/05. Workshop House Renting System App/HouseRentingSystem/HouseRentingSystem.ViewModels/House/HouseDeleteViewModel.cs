using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.ViewModels.House
{
    public class HouseDeleteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
