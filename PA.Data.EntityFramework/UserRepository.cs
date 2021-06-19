using System.Linq;
using PA.Core.Domain.Entities;
using PA.Core.Domain.Repositories;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly UserDataDbContext _context;

        public UserRepository(UserDataDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User UpdateUser(User user)
        {
            return _context.Update(user).Entity;
        }
    }
}