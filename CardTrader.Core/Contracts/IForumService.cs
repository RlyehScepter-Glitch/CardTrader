using CardTrader.Infrastructure.Data.Models;

namespace CardTrader.Core.Contracts
{
    public interface IForumService
    {
        public List<ForumThread> GetThreads();
        public ForumThread GetThread(string threadId);
        public List<ForumComment> GetComments(string threadId);
        public ForumThread CreateThread(string _userId, string _title, string _content);
        public ForumComment CreateComment(string _userId, string _username, string _threadId, string _content);
    }
}
