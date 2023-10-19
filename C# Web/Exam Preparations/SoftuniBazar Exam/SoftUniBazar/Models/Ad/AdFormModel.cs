using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.DataConstants.Ad;
using SoftUniBazar.Models.Category;

namespace SoftUniBazar.Models.Ad
{
    public class AdFormModel
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

        public List<CategoryViewModel> Categories { get; set; } =  new List<CategoryViewModel>();
    }
}
