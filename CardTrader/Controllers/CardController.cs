using CardTrader.Core.Contracts;
using CardTrader.Core.DataTransferObjects;
using CardTrader.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class CardController : BaseController
    {
        private readonly ICardService cardService;
        private readonly IRepository repo;
        private readonly UserManager<ApplicationUser> userManager;
        public CardController(ICardService _cardService,
            IRepository _repo,
            UserManager<ApplicationUser> _userManager)
        {
            cardService = _cardService;
            repo = _repo;
            userManager = _userManager;
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string cardName)
        {
            CardDTO card = cardService.CardInfo(cardName);
            ViewBag.Card = card;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            string _Name,
            string _Expansion,
            string _Rarity,
            string _Language,
            bool _FirstEdition,
            string _MinimumCondition,
            string _ImageUrl,
            string collectionName)
        {
            var user = await userManager.GetUserAsync(this.HttpContext.User);
            Collection _Collection;

            if (collectionName == "Binder")
            {
                _Collection = user.TradeBinder;
            }
            else
            {
                _Collection = user.WantedList;
            }

            Card card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _Collection);

            repo.Add(card);
            repo.SaveChanges();

            return Redirect("/Collection/Binder");
        }

    }
}
