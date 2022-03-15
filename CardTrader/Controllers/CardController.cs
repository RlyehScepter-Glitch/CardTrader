using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }
    }
}
