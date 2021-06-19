using System.Collections.Generic;

namespace PA.Core.Domain.Entities
{
    public class Client
    {
        private IList<Project> _projects;
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Project> Projects
        {
            get => _projects ??= new List<Project>();
            protected set => _projects = value;
        }
    }
}