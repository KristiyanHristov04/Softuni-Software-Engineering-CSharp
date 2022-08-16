using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Data.Models
{
    public class Car
    {
        [Required] //This property cannot be empty, so that's why we add [Required] attribute
        public string CarMake { get; set; }
        [Required]
        public string PlateNumber { get; set; }
    }
}
