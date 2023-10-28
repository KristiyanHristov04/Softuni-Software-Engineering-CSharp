using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.DataConstants.Category;

namespace HouseRentingSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Houses = new List<House>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<House> Houses { get; set; }
    }
}
