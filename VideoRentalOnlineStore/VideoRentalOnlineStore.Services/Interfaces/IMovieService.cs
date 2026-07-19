using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        public List<Cast> GetCastByMovieId(int movieId);
    }
}
