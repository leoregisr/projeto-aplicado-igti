using System;
using System.Collections.Generic;

namespace PA.Core.Repositories
{
    public interface ITimeCardRepository
    {
        TimeCardRegister GetTimeCardRegister(int id);

        TimeCardRegister EditTimeCardRegister(TimeCardRegisterViewModel timeCardRegister);

        TimeCardRegister SaveCardRegister(TimeCardRegisterViewModel timeCardRegister);

        void DeleteTimeCardRegister(int id);

        IList<TimeCardRegisterViewModel> ListTimeCardRegisterByDate(int userId, DateTime date);

        IList<TimeCardRegisterViewModel> ListTimeCardRegisterByYearAndMonth(int userId, int year, int monthNumber);
    }
}