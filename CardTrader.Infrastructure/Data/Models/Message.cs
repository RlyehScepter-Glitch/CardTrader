using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardTrader.Infrastructure.Data.Models
{
    public class Message
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey(nameof(SenderId))]
        public User Sender { get; set; }
        public string SenderId { get; set; }
        
        [Required]
        [ForeignKey(nameof(ReceiverId))]
        public User Receiver { get; set; }
        public string ReceiverId { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }
    }
}
