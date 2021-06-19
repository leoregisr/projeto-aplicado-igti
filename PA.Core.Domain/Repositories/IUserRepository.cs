using PA.Core.Domain.Entities;
using PA.Data;

namespace PA.Core.Domain.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User GetByUserName(string username);

        User UpdateUser(User user);
    }
}