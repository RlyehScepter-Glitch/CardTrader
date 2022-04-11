using CardTrader.Core.Contracts;
using CardTrader.Infrastructure.Data;
using CardTrader.Infrastructure.Data.Models;

namespace CardTrader.Core.Services
{
    public class ForumService : IForumService
    {
        private readonly ApplicationDbContext context;
        public ForumService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public List<ForumThread> GetThreads()
        {
            var threads = context
                .ForumThreads
                .ToList();

            return threads;
        }

        public ForumThread GetThread(string threadId)
        {
            var thread = context
                .ForumThreads
                .Where(t => t.Id == threadId)
                .FirstOrDefault();

            return thread;
        }

        public List<ForumComment> GetComments(string threadId)
        {
            var comments = context
                .ForumComments
                .Where(c => c.ForumThreadId == threadId)
                .ToList();

            return comments;
        }

        public ForumThread CreateThread(string _userId, string _title, string _content)
        {
            ForumThread thread = new ForumThread
            {
                CreatorId = _userId, 
                Title = _title, 
                Content = _content
            };

            return thread;
        }
    }
}
