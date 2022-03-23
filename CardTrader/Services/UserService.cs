using CardTrader.Contracts;
using CardTrader.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using CardTrader.Controllers;

namespace CardTrader.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IRepository _repo
            , UserManager<ApplicationUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public bool HasBinder(HttpContext context) => GetUser(context).Result.TradeBinder != null;
        
        public bool HasWanted(HttpContext context) => GetUser(context).Result.WantedList != null;

        private async Task<ApplicationUser> GetUser(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);
            return user;
        }


    }
}
