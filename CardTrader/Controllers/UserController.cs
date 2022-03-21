using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Account()
        {
            return View();
        }
    }
}
