using Microsoft.EntityFrameworkCore;

namespace PA.Data.Repositories.EntityFramework
{
    public class UserDataDbContext : DbContext
    {
        private readonly DbContextOptions<UserDataDbContext> _dbContextOptions;

        public UserDataDbContext(DbContextOptions<UserDataDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }   
    }
}