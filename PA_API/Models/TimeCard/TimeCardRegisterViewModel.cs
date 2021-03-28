using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PA_API.Models.TimeCard
{
    public class TimeCardRegisterViewModel
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string ProjectName { get; set; }
        
    }
}
