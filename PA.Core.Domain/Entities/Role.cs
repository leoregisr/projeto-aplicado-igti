using System.Collections.Generic;

namespace PA.Core.Domain.Entities
{
    public class Role
    {
        private IList<User> _employees;

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Wage { get; set; }

        public virtual IList<User> Employees
        {
            get => _employees ??= new List<User>();
            protected set => _employees = value;
        }
    }
}