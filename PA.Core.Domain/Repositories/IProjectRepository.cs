using System.Collections.Generic;
using PA.Core.Domain.Entities;
using PA.Data;

namespace PA.Core.Domain.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetByName(string projectName);

        IList<Project> ListByClientId(int clientId);
    }
}