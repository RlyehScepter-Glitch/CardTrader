using CardTrader.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardTrader.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Collection> Collections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardCollection>(x =>
            {
                x.HasKey(x => new { x.CardId, x.CollectionId });
            });

            modelBuilder.Entity<CardCollection>()
                .HasOne(cc => cc.Card)
                .WithMany(c => c.Collections)
                .HasForeignKey(cc => cc.CardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CardCollection>()
                .HasOne(cc => cc.Collection)
                .WithMany(c => c.Cards)
                .HasForeignKey(cc => cc.CollectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.TradeBinder)
                .WithOne(b => b.User)
                .HasForeignKey<ApplicationUser>(u => u.BinderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.WantedList)
                .WithOne(w => w.User)
                .HasForeignKey<ApplicationUser>(u => u.WantedListId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}