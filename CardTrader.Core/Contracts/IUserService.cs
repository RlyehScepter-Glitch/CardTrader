using CardTrader.Core.ViewModels;
using CardTrader.Infrastructure.Data.Models;

namespace CardTrader.Core.Contracts
{
    public interface IUserService
    {
        public ApplicationUser GetUserByName(string username);
        public IEnumerable<UserViewModel> GetListOfUsers();
        public string CardOwnerName(string collectionId);
    }
}
