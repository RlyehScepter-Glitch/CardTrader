using CardTrader.Core.Contracts;
using CardTrader.Core.Services;
using CardTrader.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly ICollectionService collectionService;

        public UserController(UserManager<ApplicationUser> _userManager,
            IUserService _userService,
            ICollectionService _collectionService)
        {
            userManager = _userManager;
            userService = _userService;
            collectionService = _collectionService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/User/User")]
        public IActionResult User(string username)
        {
            var user = userService.GetUserByName(username);

            ViewData["Username"] = username;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/User/UserBinder")]
        public IActionResult UserBinder(string username)
        {
            var user = userService.GetUserByName(username);
            var binderId = user.BinderId;

            var cards = collectionService.GetCards(binderId);

            ViewData["Username"] = username;
            ViewData["Cards"] = cards;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/User/UserWanted")]
        public IActionResult UserWanted(string username)
        {
            var user = userService.GetUserByName(username);
            var wantedListId = user.WantedListId;

            var cards = collectionService.GetCards(wantedListId);

            ViewData["Username"] = username;
            ViewData["Cards"] = cards;

            return View();
        }

        [AllowAnonymous]
        public IActionResult UserList()
        {
            var users = userService.GetListOfUsers();

            ViewData["Users"] = users;

            return View();
        }
    }
}
