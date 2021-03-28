using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PA.Core.Contracts.Entities;
using PA.Core.Contracts.Repositories;

namespace PA.Data.EntityFramework
{
    public class TimeCardRepository : ITimeCardRepository
    {
        private readonly DbContext _context;

        public TimeCardRepository(ApplicationDataDbContext context)
        {
            _context = context;
        }

        public TimeCardRegister GetTimeCardRegister(int id)
        {
            throw new NotImplementedException();
        }

        public TimeCardRegister EditTimeCardRegister(TimeCardRegister timeCardRegister)
        {
            throw new NotImplementedException();
        }

        public TimeCardRegister SaveCardRegister(TimeCardRegister timeCardRegister)
        {
            throw new NotImplementedException();
        }

        public void DeleteTimeCardRegister(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TimeCardRegister> ListTimeCardRegisterByDate(int userId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IList<TimeCardRegister> ListTimeCardRegisterByYearAndMonth(int userId, int year, int monthNumber)
        {
            throw new NotImplementedException();
        }
    }
}
