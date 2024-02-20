using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.DataConstants.Category;
namespace SeminarHub.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
