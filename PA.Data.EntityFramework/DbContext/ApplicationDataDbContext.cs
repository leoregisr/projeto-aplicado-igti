using Microsoft.EntityFrameworkCore;
using PA.Core.Domain.Entities;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework.DbContext
{
    public class ApplicationDataDbContext : DbContextBase
    {
        public ApplicationDataDbContext(DbContextOptions<ApplicationDataDbContext> options)
        {
        }

        public DbSet<TimeCardRegister> TimeCardRegisters { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDataDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));
    }
}