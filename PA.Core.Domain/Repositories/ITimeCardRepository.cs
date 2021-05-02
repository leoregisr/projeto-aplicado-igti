﻿using System;
using System.Collections.Generic;
using PA.Core.Domain.Entities;

namespace PA.Core.Domain.Repositories
{
    public interface ITimeCardRepository
    {
        TimeCardRegister GetTimeCardRegister(int id);

        TimeCardRegister EditTimeCardRegister(TimeCardRegister timeCardRegister);

        TimeCardRegister SaveCardRegister(TimeCardRegister timeCardRegister);

        void DeleteTimeCardRegister(int id);

        IList<TimeCardRegister> ListTimeCardRegisterByDate(int userId, DateTime date);

        IList<TimeCardRegister> ListTimeCardRegisterByYearAndMonth(int userId, int year, int monthNumber);
    }
}