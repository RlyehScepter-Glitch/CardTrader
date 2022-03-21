using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class CardController : BaseController
    {
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Info()
        {
            return View();
        }
    }
}
