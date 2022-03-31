using CardTrader.Core.Contracts;
using CardTrader.Core.DataTransferObjects;
using System.Net;

namespace CardTrader.Core.Services
{
    public class CardService : ICardService
    {
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
    }
}
