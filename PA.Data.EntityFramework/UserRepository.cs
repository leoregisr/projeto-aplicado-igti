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


        public User GetByUserName(string username)
        {
            return _context.Find<User>();
        }

        public User UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}