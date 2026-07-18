using Microsoft.AspNetCore.Mvc;
using VideoRentalOnlineStore.Model.ViewModels;
using VideoRentalOnlineStore.Services.Interfaces;

namespace VideoRentalOnlineStore.Controllers
{
    
    public class MovieController : Controller
    {
        private readonly IUserService _userService;

        public MovieController(IUserService userService)
        {
            _userService = userService;
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

            TempData["LoggedInCardNumber"] = user.CardNumber;
            TempData["LoggedInFullName"] = user.FullName;

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
