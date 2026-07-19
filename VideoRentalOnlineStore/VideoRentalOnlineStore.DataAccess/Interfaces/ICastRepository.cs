using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.DataAccess.Interfaces
{
    public interface ICastRepository
    {
        List<Cast> GetByMovieId(int movieId);
    }
}
