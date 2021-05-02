using PA.Core.Domain.Entities;
using PA.Core.Domain.Repositories;

namespace PA.Data.Repositories.EntityFramework
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