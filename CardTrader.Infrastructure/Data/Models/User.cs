using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardTrader.Infrastructure.Data.Models
{
    public class User
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [Required]
        [ForeignKey(nameof(BinderId))]
        public CardCollection TradeBinder = new CardCollection();
        
        public string BinderId { get; set; }

        [Required]
        [ForeignKey(nameof(WantedListId))]
        public CardCollection WantedList = new CardCollection();
        
        public string WantedListId { get; set; }

        //public List<Message> Messages { get; set; }

        //Friendlist maybe?
    }
}
