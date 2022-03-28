using CardTrader.Core.Contracts;
using CardTrader.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class CollectionController : BaseController
    {
        private readonly IRepository repo;
        private readonly ICollectionService collectionService;
        private readonly UserManager<ApplicationUser> userManager;

        public CollectionController(
            ICollectionService _collectionService,
            IRepository _repo,
            UserManager<ApplicationUser> _userManager)
        {
            collectionService = _collectionService;
            repo = _repo;
            userManager = _userManager;
        }
        
        public IActionResult Binder()
        {
            return View();
        }
        public IActionResult Wanted()
        {
            return View();
        }

        public bool HasBinder(HttpContext context) => GetUser().Result.TradeBinder != null;

        public bool HasWanted(HttpContext context) => GetUser().Result.WantedList != null;

        public async Task<ApplicationUser> GetUser()
        {
            var user = await userManager.GetUserAsync(this.HttpContext.User);
            return user;
        }

        [Route("/Collection/CreateBinder")]
        public async Task<RedirectResult> CreateBinder()
        {
            var user = await GetUser();
            var binder = collectionService.CreateBinder(user);
            
            repo.Add(binder);
            repo.SaveChanges();

            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [Route("/Collection/CreateWanted")]
        public async Task<RedirectResult> CreateWanted()
        {
            var user = await GetUser();
            var wanted = collectionService.CreateWanted(user);

            repo.Add(wanted);
            repo.SaveChanges();

            return Redirect(HttpContext.Request.Headers["Referer"]);
        }
    }
}
