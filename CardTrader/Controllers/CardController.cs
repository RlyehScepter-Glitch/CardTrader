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
        [Route("/Card/GetCard")]
        public IActionResult Create(string cardName)
        {
            CardDTO card = cardService.CardInfo(cardName);
            ViewBag.Card = card;

            return View();
        }

        [HttpPost]
        [Route("/Card/CreateCard")]
        public async Task<IActionResult> CreateCard(
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
            string _CollectionId;

            if (collectionName == "Binder")
            {
                _CollectionId = user.BinderId;
            }
            else
            {
                _CollectionId = user.WantedListId;
            }

            Card card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _CollectionId);

            repo.Add(card);
            repo.SaveChanges();

            return Redirect("/Collection/Binder");
        }

    }
}
