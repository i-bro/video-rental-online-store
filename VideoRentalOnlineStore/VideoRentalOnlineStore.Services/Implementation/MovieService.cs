using VideoRentalOnlineStore.DataAccess;
using VideoRentalOnlineStore.DataAccess.Interfaces;
using VideoRentalOnlineStore.DomainModels.Models;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly ICastRepository _castRepository;

        public MovieService(IRepository<Movie> movieRepository, ICastRepository castRepository)
        {
            _movieRepository = movieRepository;
            _castRepository = castRepository;
        }

        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public List<Cast> GetCastByMovieId(int movieId)
        {
            return _castRepository.GetByMovieId(movieId);
        }
    }
}
