using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardTrader.Infrastructure.Data.Models
{
    public abstract class Collection
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public Collection()
        {

        }
        public Collection(ApplicationUser _user)
        {
            User = _user;
            UserId = _user.Id;
        }

        //public List<Collection> BulkCards { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
        public string? UserId { get; set; }

        public ICollection<CardCollection> Cards { get; set; }
    }
}
