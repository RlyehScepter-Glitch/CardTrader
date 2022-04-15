using CardTrader.Core.Contracts;
using CardTrader.Infrastructure.Data;
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
        private readonly ApplicationDbContext context;
        private readonly ICardService cardService;

        public CollectionController(
            ICollectionService _collectionService,
            IRepository _repo,
            UserManager<ApplicationUser> _userManager,
            ApplicationDbContext _context,
            ICardService _cardService)
        {
            collectionService = _collectionService;
            repo = _repo;
            userManager = _userManager;
            context = _context;
            cardService = _cardService;
        }
        
        public IActionResult Binder()
        {
            bool hasBinder = HasBinder();
            ViewData["HasBinder"] = hasBinder;

            var user = GetUser();
            var binderId = user.Result.BinderId;
            var cards = cardService.GetCardsByCollectionId(binderId);

            ViewData["Cards"] = cards;

            return View();
        }
        public IActionResult Wanted()
        {
            bool hasWanted = HasWanted();
            ViewData["HasWanted"] = hasWanted;

            var user = GetUser();
            var wantedListId = user.Result.WantedListId;
            
            var cards = cardService.GetCardsByCollectionId(wantedListId);

            ViewData["Cards"] = cards;

            return View();
        }

        public bool HasBinder() => GetUser().Result.BinderId != null;

        public bool HasWanted() => GetUser().Result.WantedListId != null;

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
