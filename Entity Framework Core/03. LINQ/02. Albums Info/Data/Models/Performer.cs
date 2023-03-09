using System.Collections.Generic;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal NetWorth { get; set; }
        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}