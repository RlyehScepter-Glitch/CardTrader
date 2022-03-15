using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardTrader.Infrastructure.Data.Models
{
    public abstract class Collection
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        //public List<Collection> BulkCards { get; set; }

        [Required]
        public User User { get; set; }
        public string UserId { get; set; }

        public ICollection<CardCollection> Cards { get; set; }
    }
}
