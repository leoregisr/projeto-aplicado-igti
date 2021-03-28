using Microsoft.EntityFrameworkCore;

namespace PA.Data.EntityFramework
{
    public class ApplicationDataDbContext : DbContext
    {
        private readonly DbContextOptions<ApplicationDataDbContext> _dbContextOptions;

        public ApplicationDataDbContext(DbContextOptions<ApplicationDataDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }
    }
}