using System;

namespace PA.Core.Contracts.TransferObjects
{
    public class TimeCardRegisterDto
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string ProjectName { get; set; }

        public int UserId { get; set; }
    }
}