using CardTrader.Core.Contracts;
using CardTrader.Infrastructure.Data.Models;

namespace CardTrader.Core.Services
{
    public class CollectionService : ICollectionService
    {
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
    }
}
