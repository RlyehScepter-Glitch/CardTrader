using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardTrader.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        public Binder? TradeBinder { get; set; }
        public string BinderId { get; set; }

        [Required]
        public Wanted? WantedList { get; set; }
        public string WantedListId { get; set; }

        //public List<Message> Messages { get; set; }

        //Friendlist maybe?
    }
}
