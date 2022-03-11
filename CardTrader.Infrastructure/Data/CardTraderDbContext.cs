using CardTrader.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardTrader.Infrastructure.Data
{
    public class CardTraderDbContext : IdentityDbContext
    {
        public CardTraderDbContext(DbContextOptions<CardTraderDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardCollection> CardCollections { get; set; }
        public DbSet<Bulk> BulkCollections { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(x =>
            {
                x.HasKey(x => new { x.SenderId, x.ReceiverId });
            });
        }
    }
}