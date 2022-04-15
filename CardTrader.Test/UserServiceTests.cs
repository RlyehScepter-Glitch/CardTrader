﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardTrader.Core.Contracts;
using CardTrader.Core.Services;
using CardTrader.Core.ViewModels;
using CardTrader.Infrastructure.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CardTrader.Test
{
    public class UserServiceTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        
        [SetUp]
        public void Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<IUserService, UserService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
            
            SeedDb(repo);
        }

        [Test]
        public void GetUserByNameReturnsTheRightUser()
        {
            var username = "Pesho";

            var userService = serviceProvider.GetService<IUserService>();
            
            var user = userService.GetUserByName(username);

            Assert.That(user.UserName, Is.EqualTo(username));
        }

        [Test]
        public void GetListOfUsersReturnsAllUsers()
        {
            var userService = serviceProvider.GetService<IUserService>();

            List<UserViewModel> users = userService.GetListOfUsers().ToList();

            Assert.That(users.Count, Is.EqualTo(2));
        }
        
        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private void SeedDb(IRepository repo) 
        {
            var user1 = new ApplicationUser()
            {
                Id = "testId1",
                UserName = "Pesho"
            };

            var user2 = new ApplicationUser()
            {
                Id = "testId2",
                UserName = "Gosho"
            };

            repo.Add(user1);
            repo.Add(user2);
            repo.SaveChanges();
        }
    }
}
