using System;
using System.Collections.Generic;
using AutoMapper;
using PA.Core.Contracts.TransferObjects;
using PA.Core.Domain.Repositories;

namespace PA.Core.Domain.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository,
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _clientRepository = clientRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public IList<ClientDto> ListAll()
        {
            var clients = _clientRepository.ListAll();

            return _mapper.Map<List<ClientDto>>(clients);
        }

        public IList<ProjectDto> ListProjectsByClientId(int clientId)
        {
            if (clientId == 0)
                throw new ArgumentException("Invalid ClientId Parameter", nameof(clientId));

            var projects = _projectRepository.ListByClientId(clientId);

            return _mapper.Map<List<ProjectDto>>(projects);
        }
    }
}