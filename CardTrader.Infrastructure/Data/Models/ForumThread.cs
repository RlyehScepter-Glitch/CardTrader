using System.ComponentModel.DataAnnotations;

namespace CardTrader.Infrastructure.Data.Models
{
    public class ForumThread
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public ApplicationUser Creator { get; set; }
        public string CreatorId { get; set; }
        
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<ForumComment> Comments { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
