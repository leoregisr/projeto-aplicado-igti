using PA.Core.Contracts.Entities;

namespace PA.Core.Contracts.Repositories
{
    public interface IUserRepository
    {
        User Get(int id);

        User GetByUserName(string username);

        User UpdateUser(User user);
    }
}