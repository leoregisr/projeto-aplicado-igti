using System.Collections.Generic;

namespace PA.Core.Domain.Entities
{
    public class User
    {
        private IList<TimeCardRegister> _timeCardRegisters;
        private IList<User> _employees;

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual Role Role { get; set; }
        public virtual User Manager { get; set; }
        
        public virtual IList<TimeCardRegister> TimeCardRegisters
        {
            get => _timeCardRegisters ??= new List<TimeCardRegister>();
            protected set => _timeCardRegisters = value;
        }

        public virtual IList<User> Employees
        {
            get => _employees ??= new List<User>();
            protected set => _employees = value;
        }

        
    }
}