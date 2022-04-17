using CardTrader.Core.Contracts;
using CardTrader.Core.Services;
using CardTrader.Infrastructure.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CardTrader.Test
{
    public class CollectionServiceTests
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
                .AddSingleton<ICardService, CardService>()
                .AddSingleton<ICollectionService, CollectionService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            SeedDb(repo);
        }

        [Test]
        public void CreateBinderMethodCreatesBinderWithGivenUser()
        {
            var collectionService = serviceProvider.GetService<ICollectionService>();

            var testUser = new ApplicationUser()
            {
                Id = "testId1",
                UserName = "Pesho"
            };

            var binder = collectionService.CreateBinder(testUser);

            Assert.That(binder.UserId, Is.EqualTo(testUser.Id));
        }

        [Test]
        public void CreateWantedMethodCreatesWantedListWithGivenUser()
        {
            var collectionService = serviceProvider.GetService<ICollectionService>();

            var testUser = new ApplicationUser()
            {
                Id = "testId1",
                UserName = "Pesho"
            };

            var wantedList = collectionService.CreateWanted(testUser);

            Assert.That(wantedList.UserId, Is.EqualTo(testUser.Id));
        }

        [Test]
        public void GetCardsMethodReturnsListOfAllCardsFromCollection()
        {
            var collectionService = serviceProvider.GetService<ICollectionService>();

            var cards = collectionService.GetCards("testCollectionId1");

            Assert.That(cards.Count, Is.EqualTo(2));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private void SeedDb(IRepository repo)
        {
            var user = new ApplicationUser()
            {
                Id = "testUserId1",
                UserName = "Pesho"
            };

            var binder = new Binder()
            {
                Id = "testCollectionId1",
                UserId = "testUserId1",
            };
            
            var cardService = serviceProvider.GetService<ICardService>();

            var testCard1 = cardService.CreateCard("testName1", "testExpansion1", "testRarity1", "testLanguage1", true, "Pristine", "testImgUrl1", "testCollectionId1");
            var testCard2 = cardService.CreateCard("testName2", "testExpansion2", "testRarity2", "testLanguage2", false, "Poor", "testImgUrl2", "testCollectionId1");

            repo.Add(user);
            repo.Add(binder);
            repo.Add(testCard1);
            repo.Add(testCard2);
            repo.SaveChanges();
        }
    }
}
