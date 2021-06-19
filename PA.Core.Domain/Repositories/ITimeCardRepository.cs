using System;
using System.Collections.Generic;
using PA.Core.Domain.Entities;
using PA.Data;

namespace PA.Core.Domain.Repositories
{
    public interface ITimeCardRepository : IRepository<TimeCardRegister>
    {
        IList<TimeCardRegister> ListTimeCardRegisterByDate(string userEmail, DateTime date);

        IList<TimeCardRegister> ListTimeCardRegisterByYearAndMonth(string userEmail, int year, int monthNumber);
    }
}