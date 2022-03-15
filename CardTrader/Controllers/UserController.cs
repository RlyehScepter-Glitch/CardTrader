using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
    }
}
