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
                .OrderBy(c => c.CreationDate)
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

        public ForumComment CreateComment(string _userId, string _username, string _threadId, string _content)
        {
            ForumComment comment = new ForumComment
            {
                CreatorId = _userId,
                CreatorName = _username,
                ForumThreadId = _threadId,
                Content = _content
            };

            return comment;
        }
    }
}
