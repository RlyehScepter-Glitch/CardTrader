using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
