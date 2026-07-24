using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.DataAccess.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        Rental GetActiveRentalByMovieId(int movieId);
        List<Rental> GetByUserId(int userId);
    }
}
