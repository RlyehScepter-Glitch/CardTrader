using CardTrader.Core.Contracts;
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
    }
}
