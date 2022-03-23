namespace CardTrader.Contracts
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;
    }
}
