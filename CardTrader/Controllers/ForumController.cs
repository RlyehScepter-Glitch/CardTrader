using CardTrader.Core.Contracts;
using CardTrader.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CardTrader.Controllers
{
    public class ForumController : BaseController
    {
        private readonly IForumService forumService;
        private readonly IRepository repo;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public ForumController(IForumService _forumService,
            IRepository _repo,
            IUserService _userService,
            UserManager<ApplicationUser> _userManager)
        {
            forumService = _forumService;
            repo = _repo;
            userService = _userService;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            var threads = forumService.GetThreads();
            
            ViewData["Threads"] = threads;

            return View();
        }

        [HttpPost]
        [Route("/Forum/Thread")]
        public IActionResult Thread(string threadId)
        {
            var thread = forumService.GetThread(threadId);
            var comments = forumService.GetComments(threadId);
            var username = GetUser().Result.UserName;
            
            ViewData["Thread"] = thread;
            ViewData["Comments"] = comments;
            ViewData["Username"] = username;

            return View();
        }

        public IActionResult CreateThread()
        {
            var userId = GetUser()
                .Result
                .Id;

            ViewData["UserId"] = userId;

            return View();
        }
        
        [HttpPost]
        [Route("/Forum/Create")]
        public IActionResult Create(string _userId,
            string _title,
            string _content)
        {
            var thread = forumService.CreateThread(_userId, _title, _content);

            repo.Add(thread);
            repo.SaveChanges();

            return Redirect("/Forum/Index");
        }

        public async Task<ApplicationUser> GetUser()
        {
            var user = await userManager.GetUserAsync(this.HttpContext.User);
            return user;
        }

        [HttpPost]
        [Route("/Forum/AddComment")]
        public IActionResult AddComment(
            string _threadId,
            string _content)
        {
            var _userId = GetUser().Result.Id;
            var _username = GetUser().Result.UserName;
            
            var comment = forumService.CreateComment(_userId, _username, _threadId, _content);

            repo.Add(comment);
            repo.SaveChanges();

            return Redirect("/Forum/Index");
        }
    }
}
