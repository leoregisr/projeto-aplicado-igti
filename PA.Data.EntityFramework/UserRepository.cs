using PA.Core.Contracts.Entities;
using PA.Core.Contracts.Repositories;

namespace PA.Data.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDataDbContext _context;

        public UserRepository(UserDataDbContext context)
        {
            _context = context;
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