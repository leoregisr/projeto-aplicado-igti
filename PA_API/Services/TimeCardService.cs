using System;
using System.Collections.Generic;
using AutoMapper;
using PA.Core.Contracts.Entities;
using PA.Core.Contracts.Repositories;
using PA_API.Exceptions;
using PA_API.Models.TimeCard;
using PA_API.Models.User;

namespace PA_API.Services
{
    public class TimeCardService
    {
        private readonly ITimeCardRepository _timeCardRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TimeCardService(ITimeCardRepository timeCardRepository, IUserRepository userRepository, IMapper mapper)
        {
            _timeCardRepository = timeCardRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public TimeCardRegisterViewModel EditTimeCardRegister(int id, DateTime time, string projectName)
        {
            var timeCardRegister = GetTimeCardById(id);

            if (time != DateTime.MinValue)
                timeCardRegister.Date = time;

            if (!string.IsNullOrEmpty(projectName))
                timeCardRegister.ProjectName = projectName;

            timeCardRegister = _timeCardRepository.EditTimeCardRegister(timeCardRegister);
            
            return _mapper.Map<TimeCardRegisterViewModel>(timeCardRegister);
        }

        public TimeCardRegisterViewModel SaveCardRegister(int userId, DateTime time, string projectName)
        {
            var user = _userRepository.Get(userId);

            if (user == null)
                throw new EntityNotFoundException<UserViewModel>(userId);

            var timeCardRegister = new TimeCardRegister()
            {
                Date = time,
                User = user,
                ProjectName = projectName
            };

            timeCardRegister = _timeCardRepository.SaveCardRegister(timeCardRegister);

            var model = _mapper.Map<TimeCardRegisterViewModel>(timeCardRegister);

            return model;
        }

        public void DeleteTimeCardRegister(int id)
        {
            var timeCardRegister = GetTimeCardById(id);

            _timeCardRepository.DeleteTimeCardRegister(timeCardRegister.ID);
        }

        public TimeCardRegisterViewModel GetTimeCardModelById(int id)
        {
            var timeCard = GetTimeCardById(id);

            return _mapper.Map<TimeCardRegisterViewModel>(timeCard);
        }

        private TimeCardRegister GetTimeCardById(int id)
        {
            var timeCard = _timeCardRepository.GetTimeCardRegister(id);

            if (timeCard == null)
                throw new EntityNotFoundException<TimeCardRegister>(id);

            return timeCard;
        }

        public IList<TimeCardRegisterViewModel> ListTimeCardRegisterByDate(int userId, DateTime date)
        {
            var timeCardRegistries = _timeCardRepository.ListTimeCardRegisterByDate(userId, date);

            return _mapper.Map<List<TimeCardRegisterViewModel>>(timeCardRegistries);
        }

        public IList<TimeCardRegisterViewModel> ListTimeCardRegisterByYearAndMonth(int userId, int year, int monthNumber)
        {
            if (year == 0)
                throw new ArgumentException("Invalid Year Parameter", nameof(year));

            if (monthNumber < 1 || monthNumber > 12)
                throw new ArgumentException("Invalid Month Parameter", nameof(monthNumber));

            var timeCardRegistries = _timeCardRepository.ListTimeCardRegisterByYearAndMonth(userId, year, monthNumber);

            return _mapper.Map<List<TimeCardRegisterViewModel>>(timeCardRegistries);
        }
    }
}