using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardTrader.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Binder? TradeBinder { get; set; }
        [ForeignKey(nameof(TradeBinder))]
        public string? BinderId { get; set; }

        public Wanted? WantedList { get; set; }
        [ForeignKey(nameof(WantedList))]
        public string? WantedListId { get; set; }

        public ICollection<ForumThread> Threads { get; set; }
        public ICollection<ForumComment> Comments { get; set; }
    }
}
