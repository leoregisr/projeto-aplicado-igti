using System.Collections.Generic;

namespace PA.Core.Domain.Entities
{
    public class Project
    {
        private IList<TimeCardRegister> _timeCardRegisters;

        public virtual int Id { get; set; }

        public virtual Client Client { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<TimeCardRegister> TimeCardRegisters
        {
            get => _timeCardRegisters ??= new List<TimeCardRegister>();
            protected set => _timeCardRegisters = value;
        }

    }
}