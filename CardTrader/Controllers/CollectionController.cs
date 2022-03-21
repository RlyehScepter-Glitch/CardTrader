using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class CollectionController : BaseController
    {
        public IActionResult Binder()
        {
            return View();
        }
        public IActionResult Wanted()
        {
            return View();
        }
    }
}
