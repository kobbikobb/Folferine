namespace Folferine.Website.Domain.Repositories
{
    public interface IUserRepository : IRepository<Player, string>
    {
        Player GetByUserName(string userName);
    }
}