using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class CardController : BaseController
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
