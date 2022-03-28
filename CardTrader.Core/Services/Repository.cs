using CardTrader.Core.Contracts;
using CardTrader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CardTrader.Core.Services
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
