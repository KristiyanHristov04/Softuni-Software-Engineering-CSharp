using System.ComponentModel.DataAnnotations;
using static Library.Common.Constants.Book;
namespace Library.Models.Book
{
    public class BookFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range((double)RatingMinValue, (double)RatingMaxValue)]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public List<BookCategoryViewModel> Categories { get; set; } = new List<BookCategoryViewModel>();
    }
}
