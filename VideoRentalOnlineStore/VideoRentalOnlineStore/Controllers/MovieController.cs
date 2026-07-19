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

        public MovieController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
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
    }
}
