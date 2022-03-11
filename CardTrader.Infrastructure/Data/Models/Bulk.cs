using System.ComponentModel.DataAnnotations;

namespace CardTrader.Infrastructure.Data.Models
{
    public class Bulk
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public List<Card> Cards { get; set; }
    }
}
