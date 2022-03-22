namespace CardTrader.Infrastructure.Data.Models
{
    public class Wanted : Collection
    {
        public Wanted()
        {

        }
        public Wanted(ApplicationUser _user)
            :base(_user)
        {

        }
    }
}
