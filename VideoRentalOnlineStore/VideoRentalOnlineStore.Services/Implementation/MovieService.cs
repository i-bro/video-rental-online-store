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

        public void DecreaseQuantity(int movieId)
        {
            var movie = _movieRepository.GetById(movieId);
            if(movie == null || movie.Quantity <= 0)
            {
                throw new Exception("No movies available");
            }

            movie.Quantity -= 1;
            _movieRepository.Update(movie);
        }

        public void IncreaseQuantity(int movieId)
        {
            var movie = _movieRepository.GetById(movieId);
            if(movie == null)
            {
                throw new Exception("Movie not found");
            }

            movie.Quantity += 1;
            _movieRepository.Update(movie);
        }
    }
}
