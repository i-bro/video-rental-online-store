using VideoRentalOnlineStore.DomainModels.Enums;

namespace VideoRentalOnlineStore.Model.ViewModels
{
    public class MovieDetailsViewModel
    {
        public int Id {get; set;}
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public int AgeRestriction { get; set; }
        public int Quantity { get; set; }
        public List<CastViewModel> Cast {get; set; }
    }
}
