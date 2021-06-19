using Microsoft.EntityFrameworkCore;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework
{
    public class ApplicationDataDbContext : DbContextBase
    {
        public ApplicationDataDbContext(DbContextOptions<ApplicationDataDbContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDataDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));

        
    }
}