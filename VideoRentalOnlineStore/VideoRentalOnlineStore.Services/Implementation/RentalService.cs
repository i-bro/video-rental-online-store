using VideoRentalOnlineStore.DataAccess.Interfaces;
using VideoRentalOnlineStore.DomainModels.Models;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Services.Implementation
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMovieService _movieService;

        public RentalService( IMovieService movieService, IRentalRepository rentalRepository)
        {
            //_rentalRepository = rentalRepository;
            _movieService = movieService;
            _rentalRepository = rentalRepository;
        }

        public List<Rental> GetRentalByUserId(int userId)
        {
            return _rentalRepository.GetByUserId(userId);
        }

        public void RentMovie(int movieId, int userId)
        {
            var movie = _movieService.GetById(movieId);
            if(movie == null || !movie.IsAvailable)
            {
                throw new Exception("Movie is not available");
            };

            _rentalRepository.Create(new Rental
            {
                MovieId = movieId,
                UserId = userId,
                RentedOn = DateTime.Now
            });

            _movieService.DecreaseQuantity(movieId);
            
        }

        public void ReturnMovie(int movieId)
        {
            var rental = _rentalRepository.GetActiveRentalByMovieId(movieId);
            if(rental == null)
            {
                throw new Exception("No active rental found for this movie");
            }

            rental.ReturnedOn = DateTime.Now;
            _rentalRepository.Update(rental);

            _movieService.IncreaseQuantity(movieId);
        }

    }
}
