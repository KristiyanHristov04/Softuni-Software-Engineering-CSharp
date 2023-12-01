using System.ComponentModel.DataAnnotations;

namespace WebAPICORS
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        public string Brand { get; set; } = null!;

        [Required]
        public string Model { get; set; } = null!;
    }
}
