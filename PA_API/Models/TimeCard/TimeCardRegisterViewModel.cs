using System;

namespace PA_API.Models.TimeCard
{
    public class TimeCardRegisterViewModel
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string ProjectName { get; set; }

        public int UserId { get; set; }
    }
}
