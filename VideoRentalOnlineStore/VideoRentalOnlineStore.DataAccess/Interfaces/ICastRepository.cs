using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.DataAccess.Interfaces
{
    public interface ICastRepository : IRepository<Cast>
    {
        List<Cast> GetByMovieId(int movieId);
    }
}
