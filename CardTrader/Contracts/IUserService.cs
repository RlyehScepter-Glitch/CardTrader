namespace CardTrader.Contracts
{
    public interface IUserService
    {
        public bool HasBinder(HttpContext context);
        public bool HasWanted(HttpContext context);
    }
}
