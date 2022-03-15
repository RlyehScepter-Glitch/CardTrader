using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
