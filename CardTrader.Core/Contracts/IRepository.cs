namespace CardTrader.Core.Contracts
{
    public interface IRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public IQueryable<T> All<T>() where T : class;
        public int SaveChanges();
    }
}
