using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.Services.Interfaces
{
    public interface IRentalService
    {
        void RentMovie(int movieId, int userId);
        void ReturnMovie(int movieId);
        public List<Rental> GetRentalByUserId(int userId);
    }
}
