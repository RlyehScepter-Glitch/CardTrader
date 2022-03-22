using CardTrader.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }
        public IActionResult Account()
        {
            return View();
        }
    }
}
