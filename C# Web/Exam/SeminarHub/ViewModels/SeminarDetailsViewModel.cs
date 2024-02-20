namespace SeminarHub.ViewModels
{
    public class SeminarDetailsViewModel : SeminarViewModel
    {
        public string Details { get; set; } = null!;
        public int? Duration { get; set; }
    }
}
