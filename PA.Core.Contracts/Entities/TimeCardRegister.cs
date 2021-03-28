using System;

namespace PA.Core.Contracts.Entities
{
    public class TimeCardRegister
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string ProjectName { get; set; }

        public User User { get; set; }
    }
}