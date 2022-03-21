using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
