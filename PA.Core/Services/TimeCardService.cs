using System;
using System.Collections.Generic;
using PA_API.Exceptions;
using PA_API.Models.TimeCard;
using PA_API.Models.User;
using PA_API.Repositories;

namespace PA_API.Services
{
    public class TimeCardService
    {
        private readonly ITimeCardRepository _timeCardRepository;
        private readonly IUserRepository _userRepository;

        public TimeCardService(ITimeCardRepository timeCardRepository, IUserRepository userRepository)
        {
            _timeCardRepository = timeCardRepository;
            _userRepository = userRepository;
        }

        public TimeCardRegisterViewModel EditTimeCardRegister(int id, DateTime time, string projectName)
        {
            var timeCardRegister = GetTimeCardById(id);

            if (time != DateTime.MinValue)
                timeCardRegister.Date = time;

            if (!string.IsNullOrEmpty(projectName))
                timeCardRegister.ProjectName = projectName;

            return _timeCardRepository.EditTimeCardRegister(timeCardRegister);
        }

        public TimeCardRegisterViewModel SaveCardRegister(int userId, DateTime time, string projectName)
        {
            var user = _userRepository.Get(userId);

            if (user == null)
                throw new EntityNotFoundException<UserViewModel>(userId);

            var timeCardRegister = new TimeCardRegisterViewModel()
            {
                Date = time,
                User = user,
                ProjectName = projectName
            };

            return _timeCardRepository.SaveCardRegister(timeCardRegister);
        }

        public void DeleteTimeCardRegister(int id)
        {
            var timeCardRegister = GetTimeCardById(id);

            _timeCardRepository.DeleteTimeCardRegister(timeCardRegister.ID);
        }

        public TimeCardRegisterViewModel GetTimeCardById(int id)
        {
            var timeCard = _timeCardRepository.GetTimeCardRegister(id);

            if (timeCard == null)
                throw new EntityNotFoundException<TimeCardRegisterViewModel>(id);

            return timeCard;
        }

        public IList<TimeCardRegisterViewModel> ListTimeCardRegisterByDate(int userId, DateTime date)
        {
            return _timeCardRepository.ListTimeCardRegisterByDate(userId, date);
        }

        public IList<TimeCardRegisterViewModel> ListTimeCardRegisterByYearAndMonth(int userId, int year, int monthNumber)
        {
            if (year == 0)
                throw new ArgumentException("Invalid Year Parameter", nameof(year));

            if (monthNumber < 1 || monthNumber > 12)
                throw new ArgumentException("Invalid Month Parameter", nameof(monthNumber));

            return _timeCardRepository.ListTimeCardRegisterByYearAndMonth(userId, year, monthNumber);
        }
    }
}