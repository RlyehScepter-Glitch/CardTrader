using CardTrader.Infrastructure.Data.Models;

namespace CardTrader.Core.Contracts
{
    public interface IUserService
    {
        public ApplicationUser GetUserByName(string username);
    }
}
