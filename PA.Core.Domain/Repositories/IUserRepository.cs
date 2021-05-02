using PA.Core.Domain.Entities;

namespace PA.Core.Domain.Repositories
{
    public interface IUserRepository
    {
        User Get(int id);

        User GetByUserName(string username);

        User UpdateUser(User user);
    }
}