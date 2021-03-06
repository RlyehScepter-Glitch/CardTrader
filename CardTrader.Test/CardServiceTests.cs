using System;
using System.Threading.Tasks;
using CardTrader.Core.Contracts;
using CardTrader.Core.DataTransferObjects;
using CardTrader.Core.Services;
using CardTrader.Infrastructure.Data.Models;
using CardTrader.Infrastructure.Data.Models.Enumerators;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CardTrader.Test
{
    public class CardServiceTests
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
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            SeedDb(repo);
        }

        [Test]
        public void CardInfoReturnsCardDTOWithCorrectName()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string cardName = "Endymion, the Mighty Master of Magic";

            CardDTO card = cardService.CardInfo(cardName);

            Assert.That(card.data[0].name, Is.EqualTo(cardName));
        }

        [Test]
        public void CardInfoReturnsCardDTOWithCorrectImages()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string cardName = "Endymion, the Mighty Master of Magic";

            CardDTO card = cardService.CardInfo(cardName);

            Assert.That(card.data[0].card_images.Length, Is.EqualTo(1));
        }

        [Test]
        public void CardInfoReturnsCardDTOWithCorrectSetName()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string cardName = "Endymion, the Mighty Master of Magic";
            string setName = "Structure Deck: Order of the Spellcasters";

            CardDTO card = cardService.CardInfo(cardName);

            Assert.That(card.data[0].card_sets[0].set_name, Is.EqualTo(setName));
        }

        [Test]
        public void CardInfoReturnsCardDTOWithCorrectSetRarity()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string cardName = "Endymion, the Mighty Master of Magic";
            string cardRarity = "Ultra Rare";

            CardDTO card = cardService.CardInfo(cardName);

            Assert.That(card.data[0].card_sets[0].set_rarity, Is.EqualTo(cardRarity));
        }

        [Test]
        public void CreateCardCreatesCardWithCorrectName()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string _Name = "testName";
            string _Expansion = "testExpansion";
            string _Rarity = "testRarity";
            string _Language = "testLanguage";
            bool _FirstEdition = true;
            string _MinimumCondition = "Pristine";
            string _ImageUrl = "testImgUrl";
            string _CollectionId = "testCollectionId";

            var card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _CollectionId);

            Assert.That(card.Name, Is.EqualTo(_Name));
        }

        [Test]
        public void CreateCardCreatesCardWithCorrectExpansion()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string _Name = "testName";
            string _Expansion = "testExpansion";
            string _Rarity = "testRarity";
            string _Language = "testLanguage";
            bool _FirstEdition = true;
            string _MinimumCondition = "Pristine";
            string _ImageUrl = "testImgUrl";
            string _CollectionId = "testCollectionId";

            var card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _CollectionId);

            Assert.That(card.Expansion, Is.EqualTo(_Expansion));
        }

        [Test]
        public void CreateCardCreatesCardWithCorrectRarity()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string _Name = "testName";
            string _Expansion = "testExpansion";
            string _Rarity = "testRarity";
            string _Language = "testLanguage";
            bool _FirstEdition = true;
            string _MinimumCondition = "Pristine";
            string _ImageUrl = "testImgUrl";
            string _CollectionId = "testCollectionId";

            var card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _CollectionId);

            Assert.That(card.Rarity, Is.EqualTo(_Rarity));
        }

        [Test]
        public void CreateCardCreatesCardWithCorrectLanguage()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string _Name = "testName";
            string _Expansion = "testExpansion";
            string _Rarity = "testRarity";
            string _Language = "testLanguage";
            bool _FirstEdition = true;
            string _MinimumCondition = "Pristine";
            string _ImageUrl = "testImgUrl";
            string _CollectionId = "testCollectionId";

            var card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _CollectionId);

            Assert.That(card.Language, Is.EqualTo(_Language));
        }

        [Test]
        public void CreateCardCreatesCardWithCorrectEdition()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string _Name = "testName";
            string _Expansion = "testExpansion";
            string _Rarity = "testRarity";
            string _Language = "testLanguage";
            bool _FirstEdition = true;
            string _MinimumCondition = "Pristine";
            string _ImageUrl = "testImgUrl";
            string _CollectionId = "testCollectionId";

            var card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _CollectionId);

            Assert.That(card.FirstEdition, Is.EqualTo(_FirstEdition));
        }

        [Test]
        public void CreateCardCreatesCardWithCorrectCondition()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string _Name = "testName";
            string _Expansion = "testExpansion";
            string _Rarity = "testRarity";
            string _Language = "testLanguage";
            bool _FirstEdition = true;
            string _MinimumCondition = "Pristine";
            string _ImageUrl = "testImgUrl";
            string _CollectionId = "testCollectionId";

            var card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _CollectionId);

            Assert.That(card.MinimumCondition, Is.EqualTo(Enum.Parse<Condition>(_MinimumCondition)));
        }

        [Test]
        public void CreateCardCreatesCardWithCorrectImgUrl()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string _Name = "testName";
            string _Expansion = "testExpansion";
            string _Rarity = "testRarity";
            string _Language = "testLanguage";
            bool _FirstEdition = true;
            string _MinimumCondition = "Pristine";
            string _ImageUrl = "testImgUrl";
            string _CollectionId = "testCollectionId";

            var card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _CollectionId);

            Assert.That(card.ImageUrl, Is.EqualTo(_ImageUrl));
        }

        [Test]
        public void CreateCardCreatesCardWithCorrectCollectionId()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            string _Name = "testName";
            string _Expansion = "testExpansion";
            string _Rarity = "testRarity";
            string _Language = "testLanguage";
            bool _FirstEdition = true;
            string _MinimumCondition = "Pristine";
            string _ImageUrl = "testImgUrl";
            string _CollectionId = "testCollectionId";

            var card = cardService.CreateCard(_Name, _Expansion, _Rarity, _Language, _FirstEdition, _MinimumCondition, _ImageUrl, _CollectionId);

            Assert.That(card.CollectionId, Is.EqualTo(_CollectionId));
        }

        [Test]
        public void GetCardByIdReturnsCorrectCard()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            var card = cardService.GetCardById("testId1");

            Assert.That(card.Id, Is.EqualTo("testId1"));
        }

        [Test]
        public void GetCardsByCollectionIdReturnsCorrectNumberOfCards()
        {
            var cardService = serviceProvider.GetService<ICardService>();

            var cards = cardService.GetCardsByCollectionId("testCollectionId1");

            Assert.That(cards.Count, Is.EqualTo(2));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private void SeedDb(IRepository repo)
        {
            var cardService = serviceProvider.GetService<ICardService>();

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

            var testCard1 = new Card()
            {
                Id = "testId1",
                Name = "testName1",
                Expansion = "testExpansion1",
                Rarity = "testRarity1",
                Language = "testLanguage1",
                FirstEdition = true,
                MinimumCondition = Enum.Parse<Condition>("Pristine"),
                ImageUrl = "testImgUrl1",
                CollectionId = "testCollectionId1"
            };

            var testCard2 = new Card()
            {
                Id = "testId2",
                Name = "testName2",
                Expansion = "testExpansion2",
                Rarity = "testRarity2",
                Language = "testLanguage2",
                FirstEdition = true,
                MinimumCondition = Enum.Parse<Condition>("Pristine"),
                ImageUrl = "testImgUrl2",
                CollectionId = "testCollectionId1"
            };

            repo.Add(user);
            repo.Add(binder);
            repo.Add(testCard1);
            repo.Add(testCard2);
            repo.SaveChanges();
        }
    }
}
