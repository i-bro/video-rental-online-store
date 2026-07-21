using VideoRentalOnlineStore.DomainModels.Enums;
using VideoRentalOnlineStore.DomainModels.Models;

namespace VideoRentalOnlineStore.DataAccess
{
    public static class StaticDb
    {
        public static List<User> Users {get; set;} = new List<User>();
        public static List<Movie> Movies {get; set;} = new List<Movie>();
        public static List<Cast> Casts {get; set;} = new List<Cast>();
        public static List<Rental> Rentals {get; set;} = new List<Rental>();

         static StaticDb()
        {
            LoadUsers();
            LoadMovies();
            LoadCasts();
            LoadRentals();
        }

        public static void LoadUsers()
        {
            Users = new List<User>()
            {
            new User { Id = 1, FullName = "Ana Petrovska", Age = 27, CardNumber = "4111-1111-1111-1111", CreatedOn = new DateTime(2023, 3, 14), IsSubscriptionExpired = false, SubscriptionType = SubscriptionType.Premium },
            new User { Id = 2, FullName = "Marko Ilievski", Age = 34, CardNumber = "4222-2222-2222-2222", CreatedOn = new DateTime(2022, 11, 2), IsSubscriptionExpired = true, SubscriptionType = SubscriptionType.Basic },
            new User { Id = 3, FullName = "Elena Stojanovska", Age = 22, CardNumber = "4333-3333-3333-3333", CreatedOn = new DateTime(2024, 1, 19), IsSubscriptionExpired = false, SubscriptionType = SubscriptionType.Standard },
            new User { Id = 4, FullName = "Filip Trajkovski", Age = 45, CardNumber = "4444-4444-4444-4444", CreatedOn = new DateTime(2021, 6, 30), IsSubscriptionExpired = true, SubscriptionType = SubscriptionType.Premium },
            new User { Id = 5, FullName = "Jovana Ristova", Age = 19, CardNumber = "4555-5555-5555-5555", CreatedOn = new DateTime(2024, 5, 8), IsSubscriptionExpired = false, SubscriptionType = SubscriptionType.Basic }
            };
        }

        public static void LoadMovies()
        {
            Movies = new List<Movie>()
            {
                new Movie { Id = 1, Title = "Edge of Tomorrow Dawn", Genre = Genre.Action, Language = Language.English, ReleaseDate = new DateTime(2019, 7, 12), Length = new TimeSpan(2, 5, 0), AgeRestriction = 13, Quantity = 4 },
            new Movie { Id = 2, Title = "Laughing Matters", Genre = Genre.Comedy, Language = Language.English, ReleaseDate = new DateTime(2021, 3, 5), Length = new TimeSpan(1, 38, 0), AgeRestriction = 0, Quantity = 6 },
            new Movie { Id = 3, Title = "The Silent House", Genre = Genre.Horror, Language = Language.English, ReleaseDate = new DateTime(2018, 10, 26), Length = new TimeSpan(1, 30, 0), AgeRestriction = 17, Quantity = 0 },
            new Movie { Id = 4, Title = "La Vie en Rouge", Genre = Genre.Action, Language = Language.French, ReleaseDate = new DateTime(2020, 9, 14), Length = new TimeSpan(1, 55, 0), AgeRestriction = 13, Quantity = 3 },
            new Movie { Id = 5, Title = "El Camino Oculto", Genre = Genre.Horror, Language = Language.Spanish, ReleaseDate = new DateTime(2022, 2, 1), Length = new TimeSpan(1, 47, 0), AgeRestriction = 17, Quantity = 2 }
            };
        }

        public static void LoadCasts()
        {
            Casts = new List<Cast>()
            {
                new Cast { Id = 1, MovieId = 1, Name = "Tom Reyes", Part = CastPart.Actor },
            new Cast { Id = 2, MovieId = 1, Name = "Diane Foster", Part = CastPart.Director },
            new Cast { Id = 3, MovieId = 2, Name = "Chris Boyd", Part = CastPart.Actor },
            new Cast { Id = 4, MovieId = 2, Name = "Nina Alvarez", Part = CastPart.Writer },
            new Cast { Id = 5, MovieId = 3, Name = "Owen Cole", Part = CastPart.Actor },
            new Cast { Id = 6, MovieId = 3, Name = "Marta Hughes", Part = CastPart.Producer },
            new Cast { Id = 7, MovieId = 4, Name = "Jean Moreau", Part = CastPart.Actor },
            new Cast { Id = 8, MovieId = 5, Name = "Carlos Vidal", Part = CastPart.Director }

            };
        }

        public static void LoadRentals()
        {
            Rentals = new List<Rental>()
            {
            new Rental { Id = 1, MovieId = 1, UserId = 1, RentedOn = new DateTime(2026, 6, 1), ReturnedOn = new DateTime(2026, 6, 4) },
            new Rental { Id = 2, MovieId = 2, UserId = 2, RentedOn = new DateTime(2026, 6, 10), ReturnedOn = null },
            new Rental { Id = 3, MovieId = 3, UserId = 1, RentedOn = new DateTime(2026, 5, 20), ReturnedOn = new DateTime(2026, 5, 23) },
            new Rental { Id = 4, MovieId = 4, UserId = 3, RentedOn = new DateTime(2026, 7, 1), ReturnedOn = null },
            new Rental { Id = 5, MovieId = 5, UserId = 4, RentedOn = new DateTime(2026, 6, 25), ReturnedOn = new DateTime(2026, 6, 29) },
            new Rental { Id = 6, MovieId = 1, UserId = 5, RentedOn = new DateTime(2026, 7, 10), ReturnedOn = null }
            };
        }
    }
}
