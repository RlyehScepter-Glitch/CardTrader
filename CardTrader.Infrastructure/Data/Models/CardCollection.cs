using System.ComponentModel.DataAnnotations.Schema;

namespace CardTrader.Infrastructure.Data.Models
{
    public class CardCollection
    {
        [ForeignKey(nameof(CardId))]
        public Card Card { get; set; }
        public int CardId { get; set; }

        [ForeignKey(nameof(CollectionId))]
        public Collection Collection { get; set; }
        public string CollectionId { get; set; }
    }
}
