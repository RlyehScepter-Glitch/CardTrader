using CardTrader.Core.Contracts;
using CardTrader.Infrastructure.Data;
using CardTrader.Infrastructure.Data.Models;

namespace CardTrader.Core.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ApplicationDbContext context;

        public CollectionService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public Binder CreateBinder(ApplicationUser _user)
        {
            Binder binder = new Binder(_user);
            return binder;
        }
        public Wanted CreateWanted(ApplicationUser _user)
        {
            Wanted wanted = new Wanted(_user);
            return wanted;
        }

        public List<Card> GetCards(string collectionId)
        {
            var cards = context
                .Cards
                .Where(c => c.CollectionId == collectionId)
                .ToList();

            return cards;
        }
    }
}
