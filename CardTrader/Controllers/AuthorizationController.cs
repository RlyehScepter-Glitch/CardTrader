using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class AuthorizationController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
