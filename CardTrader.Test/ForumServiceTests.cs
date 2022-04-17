using CardTrader.Core.Contracts;
using CardTrader.Core.Services;
using CardTrader.Infrastructure.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CardTrader.Test
{
    public class ForumServiceTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IForumService, ForumService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            SeedDb(repo);
        }

        [Test]
        public void CreateThreadMethodCreatesThreadWithCorrectUserId()
        {
            var forumService = serviceProvider.GetService<IForumService>();
            
            string _userId = "testUserId";
            string _title = "testThreadTitle";
            string _content = "testThreadContent";

            var thread = forumService.CreateThread(_userId, _title, _content);

            Assert.That(thread.CreatorId, Is.EqualTo(_userId));
        }

        [Test]
        public void CreateThreadMethodCreatesThreadWithCorrectTitle()
        {
            var forumService = serviceProvider.GetService<IForumService>();

            string _userId = "testUserId";
            string _title = "testThreadTitle";
            string _content = "testThreadContent";

            var thread = forumService.CreateThread(_userId, _title, _content);

            Assert.That(thread.Title, Is.EqualTo(_title));
        }
        
        [Test]
        public void CreateThreadMethodCreatesThreadWithCorrectContent()
        {
            var forumService = serviceProvider.GetService<IForumService>();

            string _userId = "testUserId";
            string _title = "testThreadTitle";
            string _content = "testThreadContent";

            var thread = forumService.CreateThread(_userId, _title, _content);

            Assert.That(thread.Content, Is.EqualTo(_content));
        }

        [Test]
        public void CreateCommentMethodCreatesCommentWithCorrectUserId()
        {
            var forumService = serviceProvider.GetService<IForumService>();

            string _userId = "testUserId";
            string _username = "testUserName";
            string _threadId = "testThreadId";
            string _content = "testCommentContent";

            var comment = forumService.CreateComment(_userId, _username, _threadId, _content);

            Assert.That(comment.CreatorId, Is.EqualTo(_userId));
        }

        [Test]
        public void CreateCommentMethodCreatesCommentWithCorrectUsername()
        {
            var forumService = serviceProvider.GetService<IForumService>();

            string _userId = "testUserId";
            string _username = "testUserName";
            string _threadId = "testThreadId";
            string _content = "testCommentContent";

            var comment = forumService.CreateComment(_userId, _username, _threadId, _content);

            Assert.That(comment.CreatorName, Is.EqualTo(_username));
        }

        [Test]
        public void CreateCommentMethodCreatesCommentWithCorrectThreadId()
        {
            var forumService = serviceProvider.GetService<IForumService>();

            string _userId = "testUserId";
            string _username = "testUserName";
            string _threadId = "testThreadId";
            string _content = "testCommentContent";

            var comment = forumService.CreateComment(_userId, _username, _threadId, _content);

            Assert.That(comment.ForumThreadId, Is.EqualTo(_threadId));
        }

        [Test]
        public void CreateCommentMethodCreatesCommentWithCorrectContent()
        {
            var forumService = serviceProvider.GetService<IForumService>();

            string _userId = "testUserId";
            string _username = "testUserName";
            string _threadId = "testThreadId";
            string _content = "testCommentContent";

            var comment = forumService.CreateComment(_userId, _username, _threadId, _content);

            Assert.That(comment.Content, Is.EqualTo(_content));
        }

        [Test]
        public void GetThreadsMethodReturnsAllThreads()
        {
            var forumService = serviceProvider.GetService<IForumService>();

            var threads = forumService.GetThreads();

            Assert.That(threads.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetThreadMethodReturnsCorrectThread()
        {
            var forumService = serviceProvider.GetService<IForumService>();

            var threads = forumService.GetThreads();
            var thread = threads[0];
            string testThreadId = thread.Id;

            var testThread = forumService.GetThread(testThreadId);

            Assert.That(thread.Id, Is.EqualTo(testThreadId));
        }

        [Test]
        public void GetCommentsMethodReturnsAllCommentsOfThread()
        {
            var forumService = serviceProvider.GetService<IForumService>();

            var threads = forumService.GetThreads();
            var thread = threads[0];
            string testThreadId = thread.Id;

            var testComments = forumService.GetComments(testThreadId);

            Assert.That(testComments.Count, Is.EqualTo(2));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private void SeedDb(IRepository repo)
        {
            var forumService = serviceProvider.GetService<IForumService>();

            var user1 = new ApplicationUser()
            {
                Id = "testId1",
                UserName = "Pesho"
            };

            string _userId = user1.Id;
            string _content = "testThreadContent";

            var testThread1 = forumService.CreateThread(_userId, "testThreadTitle1", _content);
            var testThread2 = forumService.CreateThread(_userId, "testThreadTitle2", _content);

            string _threadId = testThread1.Id;
            string _username = user1.UserName;

            var testComment1 = forumService.CreateComment(_userId, _username, _threadId, _content);
            var testComment2 = forumService.CreateComment(_userId, _username, _threadId, _content);

            repo.Add(user1);
            repo.Add(testThread1);
            repo.Add(testThread2);
            repo.Add(testComment1);
            repo.Add(testComment2);
            repo.SaveChanges();
        }
    }
}
