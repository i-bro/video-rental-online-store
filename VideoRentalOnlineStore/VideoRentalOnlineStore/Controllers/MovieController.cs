using Microsoft.AspNetCore.Mvc;
using VideoRentalOnlineStore.Mapper;
using VideoRentalOnlineStore.Model.ViewModels;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Controllers
{
    
    public class MovieController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        private readonly IRentalService _rentalService;

        public MovieController(IUserService userService, IMovieService movieService, IRentalService rentalServise)
        {
            _userService = userService;
            _movieService = movieService;
            _rentalService = rentalServise;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userService.GetByCardNumber(model.CardNumber);

            if(user == null)
            {
                ModelState.AddModelError("", "Invalid card number");
                return View(model);
            }

            var loggedInUser = user.Map();

            HttpContext.Session.SetString("CardNumber", loggedInUser.CardNumber);
            HttpContext.Session.SetString("FullName", loggedInUser.FullName);

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var cardNumber = HttpContext.Session.GetString("CardNumber");
            var userName = HttpContext.Session.GetString("FullName");
            ViewBag.FullName = userName;
            if (string.IsNullOrEmpty(cardNumber))
            {
                return RedirectToAction("Login");
            }

            var movies = _movieService.GetAll()
                .Select(m => m.Map())
                .ToList();

            return View(movies);
        }

        public IActionResult MovieDetails(int id)
        {
            var cardNumber = HttpContext.Session.GetString("CardNumber");
            if (string.IsNullOrEmpty(cardNumber))
            {
                return RedirectToAction("Login");
            }

            var movie = _movieService.GetById(id);
            if(movie == null)
            {
                return NotFound();
            }

            var castMembers = _movieService.GetCastByMovieId(id);

            var movieDetails = movie.MapToDetails();
            
            movieDetails.Cast = castMembers.Select(c => c.MapCast()).ToList();

            return View(movieDetails);
        }

        [HttpPost]
        public IActionResult Rent(int movieId)
        {
            var cardNumber = HttpContext.Session.GetString("CardNumber");
            if (string.IsNullOrEmpty(cardNumber))
            {
                return RedirectToAction("Login");
            }
            var user = _userService.GetByCardNumber(cardNumber);

            _rentalService.RentMovie(movieId, user.Id);

            return RedirectToAction("MovieDetails", new {id = movieId});
        }

        public IActionResult MyRentals()
        {
            var cardNumber = HttpContext.Session.GetString("CardNumber");
            if (string.IsNullOrEmpty(cardNumber))
            {
                return RedirectToAction("Login");
            }

            var user = _userService.GetByCardNumber(cardNumber);
            var rentals = _rentalService.GetRentalByUserId(user.Id);

            var rentedMovies = rentals
                .Select(r => r.MapRentedModel(_movieService.GetById(r.MovieId)))
                .ToList();

            return View(rentedMovies);
        }

        [HttpPost]
        public IActionResult Return(int movieId)
        {
            var cardNumber = HttpContext.Session.GetString("CardNumber");
            if (string.IsNullOrEmpty(cardNumber))
            {
                return RedirectToAction("Login");
            }

            _rentalService.ReturnMovie(movieId);

            return RedirectToAction("MyRentals");
        }
    }
}
