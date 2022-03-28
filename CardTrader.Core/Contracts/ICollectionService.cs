using CardTrader.Infrastructure.Data.Models;

namespace CardTrader.Core.Contracts
{
    public interface ICollectionService
    {
        public Binder CreateBinder(ApplicationUser _user);
        public Wanted CreateWanted(ApplicationUser _user);
    }
}
