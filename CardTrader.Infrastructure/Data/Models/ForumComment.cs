using System.ComponentModel.DataAnnotations;

namespace CardTrader.Infrastructure.Data.Models
{
    public class ForumComment
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public ApplicationUser Creator { get; set; }
        public string CreatorId { get; set; }

        [Required]
        public string Content { get; set; }

        public ForumThread ForumThread { get; set; }
        public string ForumThreadId { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
