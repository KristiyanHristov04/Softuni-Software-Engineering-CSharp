using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        [Required]
        [ForeignKey(nameof(Collector))]
        public string CollectorId { get; set; } = null!;
        public IdentityUser Collector { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}
