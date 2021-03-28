using PA.Core.Contracts.Entities;
using PA.Core.Contracts.Repositories;

namespace PA.Data.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        public UserDataDbContext Context { get; }

        public UserRepository(UserDataDbContext context)
        {
            Context = context;
        }

        public User Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetByUserName(string username)
        {
            throw new System.NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}