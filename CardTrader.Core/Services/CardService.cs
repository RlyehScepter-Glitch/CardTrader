using CardTrader.Core.Contracts;
using CardTrader.Core.DataTransferObjects;
using CardTrader.Infrastructure.Data;
using CardTrader.Infrastructure.Data.Models;
using CardTrader.Infrastructure.Data.Models.Enumerators;
using System.Net;

namespace CardTrader.Core.Services
{
    public class CardService : ICardService
    {
        private readonly ApplicationDbContext context;

        public CardService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public CardDTO CardInfo(string cardName)
        {
            string FormatedCardName = cardName.Trim().Replace(" ", "%20");
            string url = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?name={FormatedCardName}";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseText = reader.ReadToEnd();
            response.Headers.Add("Content-type", "text/json");

            CardDTO card = Newtonsoft.Json.JsonConvert.DeserializeObject<CardDTO>(responseText);

            return card;
        }

        public Card CreateCard(
            string _Name,
            string _Expansion,
            string _Rarity,
            string _Language,
            bool _FirstEdition,
            string _MinimumCondition,
            string _ImageUrl,
            string _CollectionId)
        {
            Card card = new Card
            {
                Name = _Name,
                Expansion = _Expansion,
                Rarity = _Rarity,
                Language = _Language,
                FirstEdition = _FirstEdition,
                MinimumCondition = Enum.Parse<Condition>(_MinimumCondition),
                ImageUrl = _ImageUrl,
                CollectionId = _CollectionId
            };

            return card;
        }

        public Card GetCardById(string cardId)
        {
            var card = context
                .Cards
                .Where(c => c.Id == cardId)
                .FirstOrDefault();

            return card;
        }

        public List<Card> GetCardsByCollectionId(string collectionId)
        {
            var cards = context
                .Cards
                .Where(c => c.CollectionId == collectionId)
                .ToList();

            return cards;
        }
    }
}
