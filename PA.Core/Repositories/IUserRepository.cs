using PA_API.Models.User;

namespace PA_API.Repositories
{
    public interface IUserRepository
    {
        UserViewModel Get(int id);

        UserViewModel GetByUserName(string username);

        UserViewModel UpdateUser(UserViewModel user);
    }
}