using System.Collections.Generic;
using System.Linq;
using PA.Core.Domain.Entities;
using PA.Core.Domain.Repositories;
using PA.Data.Repositories.EntityFramework.DbContext;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework.Repositories
{
    public class ClientRepository: RepositoryBase<Client>, IClientRepository
    {
        private readonly ApplicationDataDbContext _context;

        public ClientRepository(ApplicationDataDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<Client> ListAll()
        {
            return _context.Clients.ToList();
        }
    }
}