using CardTrader.Contracts;
using CardTrader.Infrastructure.Data;
using CardTrader.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CardTrader.Services
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public Repository(ApplicationDbContext context
            , UserManager<ApplicationUser> _userManager)
        {
            dbContext = context;
            userManager = _userManager;
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}
