using CardTrader.Core.DataTransferObjects;

namespace CardTrader.Core.Contracts
{
    public interface ICardService
    {
        public CardDTO CardInfo(string cardName);
    }
}
