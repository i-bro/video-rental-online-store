using VideoRentalOnlineStore.DomainModels.Models;
using VideoRentalOnlineStore.Model.ViewModels;

namespace VideoRentalOnlineStore.Mapper
{
    public static class MovieMapper
    {
        public static MovieViewModel Map(this Movie movie)
        {
            return new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                IsAvailable = movie.IsAvailable
            };
        }

        public static MovieDetailsViewModel MapToDetails(this Movie movie)
        {
            return new MovieDetailsViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity,
                Length = movie.Length
            };
        }
    }
}
