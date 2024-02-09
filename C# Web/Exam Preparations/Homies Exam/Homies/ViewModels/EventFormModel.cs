using System.ComponentModel.DataAnnotations;
using static Homies.Common.DataConstants.Event;

namespace Homies.ViewModels
{
    public class EventFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public List<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
