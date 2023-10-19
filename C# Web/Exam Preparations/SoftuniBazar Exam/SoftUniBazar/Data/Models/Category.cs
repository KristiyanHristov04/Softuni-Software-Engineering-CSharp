using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.DataConstants.Category;

namespace SoftUniBazar.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Ads = new List<Ad>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Ad> Ads { get; set; }
    }
}
