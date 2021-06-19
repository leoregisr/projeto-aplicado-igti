using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PA.Common.Extensions;

namespace PA.Data.Repositories.EntityFramework.EF
{
	public abstract class DbContextBase : DbContext, IEfDbContext
    {
        //protected DbContextBase(DbContextOptions<DbContextBase> options)
        //{
            
        //}

        private string _connectionString;

        protected string GetConnectionString(string connectionName)
        {
            if (!string.IsNullOrEmpty(_connectionString)) return _connectionString;
            var config = JsonFileConfiguration.Get(false);
            return _connectionString = config.GetConnectionString(connectionName);
        }
    }
}