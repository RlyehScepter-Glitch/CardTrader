using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
