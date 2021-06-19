using System;

namespace PA.Core.Domain.Entities
{
    public class TimeCardRegister
    {
        public virtual int Id { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }
    }
}