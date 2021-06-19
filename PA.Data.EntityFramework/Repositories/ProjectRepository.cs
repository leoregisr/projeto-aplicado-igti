using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PA.Core.Domain.Entities;
using PA.Core.Domain.Repositories;
using PA.Data.Repositories.EntityFramework.DbContext;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        private readonly ApplicationDataDbContext _context;

        public ProjectRepository(ApplicationDataDbContext context): base(context)
        {
            _context = context;
        }

        public Project GetByName(string projectName)
        {
            return _context.Projects
                .Include(p => p.Client)
                .FirstOrDefault(p => p.Name.ToLower() == projectName.ToLower());
        }

        public IList<Project> ListByClientId(int clientId)
        {
            return _context.Projects
                .Include(p => p.Client)
                .Where(p => p.Client.Id == clientId)
                .ToList();
        }
    }
}