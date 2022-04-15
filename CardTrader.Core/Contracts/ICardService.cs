using CardTrader.Core.DataTransferObjects;
using CardTrader.Infrastructure.Data.Models;

namespace CardTrader.Core.Contracts
{
    public interface ICardService
    {
        public CardDTO CardInfo(string cardName);

        public Card CreateCard(
            string _Name,
            string _Expansion,
            string _Rarity,
            string _Language,
            bool _FirstEdition,
            string _MinimumCondition,
            string _ImageUrl,
            string _CollectionId);

        public Card GetCardById(string cardId);
    }
}
