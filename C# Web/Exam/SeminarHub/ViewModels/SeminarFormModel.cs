using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.DataConstants.Seminar;
namespace SeminarHub.ViewModels
{
    public class SeminarFormModel
    {
        [Required]
        [StringLength(TopicMaxLength, MinimumLength = TopicMinLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(LecturerMaxLength, MinimumLength = LecturerMinLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [StringLength(DetailsMaxLength, MinimumLength = DetailsMinLength)]
        public string Details { get; set; } = null!;

        [Required]
        [RegularExpression($"{DateFormatRegex}", ErrorMessage = $"Date format must be: {DateAndTimeFormat}")]
        public string DateAndTime { get; set; } = null!;

        [Range(DurationMin, DurationMax)]
        public int? Duration { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<CategoryViewModel> Categories { get; set; } 
            = new List<CategoryViewModel>();
    }
}
