using ForumApp.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumApp.Data.Models
{
    public class Post
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DataConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DataConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
