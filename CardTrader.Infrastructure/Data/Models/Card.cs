using CardTrader.Infrastructure.Data.Models.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace CardTrader.Infrastructure.Data.Models
{
    public class Card
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        public string Expansion { get; set; }

        public string Rarity { get; set; }

        public string Language { get; set; }

        public bool FirstEdition = false;

        public Condition MinimumCondition { get; set; } = Condition.Poor;
        
        [Required]
        public string ImageUrl { get; set; }

        public Collection Collection { get; set; } 
        public string CollectionId { get; set; }
    }
}
