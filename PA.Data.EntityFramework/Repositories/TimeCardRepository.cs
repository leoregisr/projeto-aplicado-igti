using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PA.Core.Domain.Entities;
using PA.Core.Domain.Repositories;
using PA.Data.Repositories.EntityFramework.DbContext;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework.Repositories
{
    public class TimeCardRepository : RepositoryBase<TimeCardRegister>, ITimeCardRepository
    {
        private readonly ApplicationDataDbContext _context;

        public TimeCardRepository(ApplicationDataDbContext context): base(context)
        {
            _context = context;
        }

        public IList<TimeCardRegister> ListTimeCardRegisterByDate(string userEmail, DateTime date)
        {
            return _context.TimeCardRegisters
                .Include(tc => tc.Project)
                .Include(tc => tc.User)
                .Where(TimeCardRegistersByDatePredicate(userEmail, date))
                .ToList();
        }

        private static Expression<Func<TimeCardRegister, bool>> TimeCardRegistersByDatePredicate(string userEmail, DateTime date)
        {
            return tc => tc.User.Email == userEmail && 
                         date >= tc.StartDate.Date && 
                         tc.EndDate.HasValue && 
                         date <= tc.EndDate.Value.Date;
        }

        public IList<TimeCardRegister> ListTimeCardRegisterByYearAndMonth(string userEmail, int year, int monthNumber)
        {
            return _context.TimeCardRegisters
                .Include(tc => tc.Project)
                .Include(tc => tc.User)
                .Where(tc => tc.User.Email == userEmail && tc.StartDate.Year == year && tc.StartDate.Month == monthNumber)
                .ToList();
        }
    }
}
