using VideoRentalOnlineStore.DomainModels.Enums;

namespace VideoRentalOnlineStore.Model.ViewModels
{
    public class MovieViewModel
    {
        public int Id {get; set;}
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; }
    }
}
