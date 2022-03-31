using CardTrader.Infrastructure.Data.Models.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace CardTrader.Infrastructure.Data.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Expansion { get; set; }

        public Rarity Rarity { get; set; }

        public string Language { get; set; }

        public bool FirstEdition { get; set; }

        public Condition MinimumCondition { get; set; } = Condition.Poor;
        
        [Required]
        public string ImageUrl { get; set; }

        public ICollection<CardCollection> Collections { get; set; }
    }
}
