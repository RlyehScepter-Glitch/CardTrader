using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class ForumController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Thread()
        {
            return View();
        }
    }
}
