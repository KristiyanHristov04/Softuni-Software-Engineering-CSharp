using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models
{
    public class SeminarParticipant
    {
        [Required]
        [ForeignKey(nameof(Seminar))]
        public int SeminarId { get; set; }
        public Seminar Seminar { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Participant))]
        public string ParticipantId { get; set; } = null!;
        public IdentityUser Participant { get; set; } = null!;
    }
}