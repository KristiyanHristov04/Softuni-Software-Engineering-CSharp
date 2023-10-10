using ForumApp.Data.Constants;
using System.ComponentModel.DataAnnotations;
using ForumApp.Data.Models;

namespace ForumApp.Models.Post
{
    public class PostFormModel
    {
        [Required]
        [StringLength(DataConstants.TitleMaxLength, MinimumLength = DataConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ContentMaxLength, MinimumLength = DataConstants.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
