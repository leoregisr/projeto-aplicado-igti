using System;

namespace PA.Core.Contracts.TransferObjects
{
    public class TimeCardRegisterDto
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int UserId { get; set; }

        public string UserEmail { get; set; }
    }
}