using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Board.NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
