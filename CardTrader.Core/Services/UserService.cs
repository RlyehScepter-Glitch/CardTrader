using CardTrader.Core.Contracts;
using CardTrader.Core.ViewModels;
using CardTrader.Infrastructure.Data;
using CardTrader.Infrastructure.Data.Models;

namespace CardTrader.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public ApplicationUser GetUserByName(string username)
        {
            var user = context
                .Users
                .Where(u => u.UserName == username)
                .FirstOrDefault();

            return user;
        }

        public IEnumerable<UserViewModel> GetListOfUsers()
        {
            var users = context
                .Users
                .Select(u => new UserViewModel
                {
                    UserName = u.UserName,
                    BinderId = u.BinderId,
                    WantedListId = u.WantedListId
                })
                .ToList();

            return users;
        }
        public string CardOwnerName(string collectionId)
        {
            var cardOwner = context
                .Users
                .Where(u => u.BinderId == collectionId ||
                            u.WantedListId == collectionId)
                .FirstOrDefault();

            var cardOwnerName = cardOwner.UserName;

            return cardOwnerName;
        }
    }
}
