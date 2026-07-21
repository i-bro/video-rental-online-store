using VideoRentalOnlineStore.DataAccess.Interfaces;
using VideoRentalOnlineStore.DomainModels.Models;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Services.Implementation
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IRepository<Rental> _rentalRepositoryCRUD;
        private readonly IMovieService _movieService;

        public RentalService(IRentalRepository rentalRepository, IMovieService movieService, IRepository<Rental> rentalRepositoryCRUD)
        {
            _rentalRepository = rentalRepository;
            _movieService = movieService;
            _rentalRepositoryCRUD = rentalRepositoryCRUD;
        }
        public void RentMovie(int movieId, int userId)
        {
            var movie = _movieService.GetById(movieId);
            if(movie == null || !movie.IsAvailable)
            {
                throw new Exception("Movie is not available");
            };

            _rentalRepositoryCRUD.Create(new Rental
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
            _rentalRepositoryCRUD.Update(rental);

            _movieService.IncreaseQuantity(movieId);
        }
    }
}
