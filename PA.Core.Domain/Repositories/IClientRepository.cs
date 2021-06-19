using System.Collections;
using System.Collections.Generic;
using PA.Core.Domain.Entities;
using PA.Data;

namespace PA.Core.Domain.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        IList<Client> ListAll();
    }
}