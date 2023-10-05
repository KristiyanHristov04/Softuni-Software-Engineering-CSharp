using static Library.Common.DataConstants.Category;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
