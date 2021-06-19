using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PA.Common.Extensions;

namespace PA.Data.Repositories.EntityFramework.EF
{
	public abstract class DbContextBase : DbContext, IEfDbContext
    {
        private string _connectionString;

        protected string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_connectionString)) return _connectionString;
            var config = JsonFileConfiguration.Get(false);
            return _connectionString = config.GetConnectionString("DefaultConnection");
        }
    }
}