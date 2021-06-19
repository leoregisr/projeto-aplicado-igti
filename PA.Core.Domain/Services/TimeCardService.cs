using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public TimeCardService(
            ITimeCardRepository timeCardRepository,
            IUserRepository userRepository,
            IProjectRepository projectRepository,
            IMapper mapper
        )
        {
            _timeCardRepository = timeCardRepository;
            _userRepository = userRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<TimeCardRegisterDto> AddTimeCardRegister(TimeCardRegisterDto timeCardRegisterDto)
        {
            var user = _userRepository.GetByEmail(timeCardRegisterDto.UserEmail);

            if (user == null)
                throw new EntityNotFoundException<User>(timeCardRegisterDto.UserId);

            if (timeCardRegisterDto.ProjectId == 0)
                throw new ArgumentNullException(nameof(timeCardRegisterDto.ProjectId),
                    "O valor do Id do Projeto não pode ser 0");

            var project = _projectRepository.Get(timeCardRegisterDto.ProjectId);

            if (project == null)
                throw new EntityNotFoundException<Project>(timeCardRegisterDto.ProjectId);

            var timeCardRegister = new TimeCardRegister()
            {
                StartDate = timeCardRegisterDto.StartDate,
                User = user,
                Project = project
            };

            timeCardRegister = await _timeCardRepository.AddAsync(timeCardRegister);

            var model = _mapper.Map<TimeCardRegisterDto>(timeCardRegister);

            return model;
        }

        public async Task<TimeCardRegisterDto> EditTimeCardRegister(TimeCardRegisterDto timeCardRegisterDto)
        {
            var timeCardRegister = GetTimeCardById(timeCardRegisterDto.Id);

            if (timeCardRegisterDto.StartDate != DateTime.MinValue)
                timeCardRegister.StartDate = timeCardRegisterDto.StartDate;

            if (timeCardRegisterDto.EndDate != DateTime.MinValue)
                timeCardRegister.EndDate = timeCardRegisterDto.EndDate;

            if (timeCardRegisterDto.ProjectId == 0)
                throw new ArgumentNullException(nameof(timeCardRegisterDto.ProjectId),
                    "O valor do Id do Projeto não pode ser 0");

            if (timeCardRegisterDto.ProjectId != timeCardRegister.Project.Id)
            {
                var project = _projectRepository.Get(timeCardRegisterDto.ProjectId);

                if (project == null)
                    throw new EntityNotFoundException<Project>(timeCardRegisterDto.ProjectId);

                timeCardRegister.Project = project;
            }

            await _timeCardRepository.UpdateAsync(timeCardRegister);
            
            return _mapper.Map<TimeCardRegisterDto>(timeCardRegister);
        }

       

        public async Task DeleteTimeCardRegister(int id)
        {
            var timeCardRegister = GetTimeCardById(id);

            await _timeCardRepository.RemoveAsync(timeCardRegister);
        }

        public TimeCardRegisterDto GetTimeCardModelById(int id)
        {
            var timeCard = GetTimeCardById(id);

            return _mapper.Map<TimeCardRegisterDto>(timeCard);
        }

        private TimeCardRegister GetTimeCardById(int id)
        {
            var timeCard = _timeCardRepository.Get(id);

            if (timeCard == null)
                throw new EntityNotFoundException<TimeCardRegister>(id);

            return timeCard;
        }

        public IList<TimeCardRegisterDto> ListTimeCardRegisterByDate(string userEmail, DateTime date)
        {
            var timeCardRegistries = _timeCardRepository.ListTimeCardRegisterByDate(userEmail, date);

            return _mapper.Map<List<TimeCardRegisterDto>>(timeCardRegistries);
        }

        public IList<TimeCardRegisterDto> ListTimeCardRegisterByYearAndMonth(string userEmail, int year, int monthNumber)
        {
            if (year == 0)
                throw new ArgumentException("Invalid Year Parameter", nameof(year));

            if (monthNumber < 1 || monthNumber > 12)
                throw new ArgumentException("Invalid Month Parameter", nameof(monthNumber));

            var timeCardRegistries = _timeCardRepository.ListTimeCardRegisterByYearAndMonth(userEmail, year, monthNumber);

            return _mapper.Map<List<TimeCardRegisterDto>>(timeCardRegistries);
        }
    }
}