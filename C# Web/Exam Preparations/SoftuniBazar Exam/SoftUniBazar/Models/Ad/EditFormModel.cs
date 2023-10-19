using SoftUniBazar.Models.Category;
using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.DataConstants.Ad;

namespace SoftUniBazar.Models.Ad
{
    public class EditFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
