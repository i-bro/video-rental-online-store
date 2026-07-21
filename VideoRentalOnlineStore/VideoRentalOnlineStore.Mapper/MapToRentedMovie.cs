using System.Runtime.CompilerServices;
using VideoRentalOnlineStore.DomainModels.Models;
using VideoRentalOnlineStore.Model.ViewModels;

namespace VideoRentalOnlineStore.Mapper
{
    public static class MapToRentedMovie
    {
        public static RentedMovieViewModel MapRentedModel(this Rental rental, Movie movie)
        {
            return new RentedMovieViewModel
            {
                MovieId = rental.MovieId,
                Title = movie.Title,
                RentedOn = rental.RentedOn
            };
        }
    }
}
