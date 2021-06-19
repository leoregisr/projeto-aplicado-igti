using Microsoft.EntityFrameworkCore;
using PA.Core.Domain.Entities;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework
{
    public class UserDataDbContext : DbContextBase
    {
        public DbSet<User> Users { get; set; }

        public UserDataDbContext(DbContextOptions<UserDataDbContext> options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDataDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(GetConnectionString("UserDataConnection"));
	}
}