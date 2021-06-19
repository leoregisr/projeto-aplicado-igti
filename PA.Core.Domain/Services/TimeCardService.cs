using System;
using System.Collections.Generic;
using AutoMapper;
using PA.Common.Exceptions;
using PA.Core.Contracts.TransferObjects;
using PA.Core.Domain.Entities;
using PA.Core.Domain.Repositories;

namespace PA.Core.Domain.Services
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

        public TimeCardRegisterDto EditTimeCardRegister(int id, DateTime time, string projectName)
        {
            var timeCardRegister = GetTimeCardById(id);

            //if (time != DateTime.MinValue)
            //    timeCardRegister.Date = time;

            //if (!string.IsNullOrEmpty(projectName))
            //    timeCardRegister.ProjectName = projectName;

            timeCardRegister = _timeCardRepository.EditTimeCardRegister(timeCardRegister);
            
            return _mapper.Map<TimeCardRegisterDto>(timeCardRegister);
        }

        public TimeCardRegisterDto SaveCardRegister(int userId, DateTime time, string projectName)
        {
            var user = _userRepository.Get(userId);

            if (user == null)
                throw new EntityNotFoundException<UserDto>(userId);

            var timeCardRegister = new TimeCardRegister()
            {
                //Date = time,
                //User = user,
                //ProjectName = projectName
            };

            timeCardRegister = _timeCardRepository.SaveCardRegister(timeCardRegister);

            var model = _mapper.Map<TimeCardRegisterDto>(timeCardRegister);

            return model;
        }

        public void DeleteTimeCardRegister(int id)
        {
            var timeCardRegister = GetTimeCardById(id);

            _timeCardRepository.DeleteTimeCardRegister(timeCardRegister.Id);
        }

        public TimeCardRegisterDto GetTimeCardModelById(int id)
        {
            var timeCard = GetTimeCardById(id);

            return _mapper.Map<TimeCardRegisterDto>(timeCard);
        }

        private TimeCardRegister GetTimeCardById(int id)
        {
            var timeCard = _timeCardRepository.GetTimeCardRegister(id);

            if (timeCard == null)
                throw new EntityNotFoundException<TimeCardRegister>(id);

            return timeCard;
        }

        public IList<TimeCardRegisterDto> ListTimeCardRegisterByDate(int userId, DateTime date)
        {
            var timeCardRegistries = _timeCardRepository.ListTimeCardRegisterByDate(userId, date);

            return _mapper.Map<List<TimeCardRegisterDto>>(timeCardRegistries);
        }

        public IList<TimeCardRegisterDto> ListTimeCardRegisterByYearAndMonth(int userId, int year, int monthNumber)
        {
            if (year == 0)
                throw new ArgumentException("Invalid Year Parameter", nameof(year));

            if (monthNumber < 1 || monthNumber > 12)
                throw new ArgumentException("Invalid Month Parameter", nameof(monthNumber));

            var timeCardRegistries = _timeCardRepository.ListTimeCardRegisterByYearAndMonth(userId, year, monthNumber);

            return _mapper.Map<List<TimeCardRegisterDto>>(timeCardRegistries);
        }
    }
}