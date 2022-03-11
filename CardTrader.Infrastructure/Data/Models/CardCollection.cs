using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardTrader.Infrastructure.Data.Models
{
    public class CardCollection
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public List<Card> Cards { get; set; }
        
        public List<Bulk> BulkCards { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
