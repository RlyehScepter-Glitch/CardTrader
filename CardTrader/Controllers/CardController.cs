using CardTrader.Core.Contracts;
using CardTrader.Core.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class CardController : BaseController
    {
        private readonly ICardService cardService;
        public CardController(ICardService _cardService)
        {
            cardService = _cardService;
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
    }
}
