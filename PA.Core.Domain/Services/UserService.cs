using AutoMapper;
using PA.Common.Exceptions;
using PA.Core.Contracts.TransferObjects;
using PA.Core.Domain.Repositories;

namespace PA.Core.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);

            if (user == null)
                throw new InvalidLoginOrPasswordException();

            if (PasswordHasher.VerifyHashedPassword(user.Password, password))
                throw new InvalidLoginOrPasswordException();

            var result = _mapper.Map<UserDto>(user);

            result.Role = user.Role?.Name;

            return result;
        }

        public UserDto Login(string token)
        {
            var tokenInfo = TokenService.ParseToken(token);

            var user = _userRepository.Get(int.Parse(tokenInfo.Id));

            if (user == null)
                throw new InvalidLoginOrPasswordException();

            return _mapper.Map<UserDto>(user);
        }

        public UserDto UpdateUser(UserDto userViewModel)
        {
            var user = _userRepository.Get(userViewModel.Id);

            user.Email = PasswordHasher.HashPassword(userViewModel.Password);
            user.Role = user.Role;

            user = _userRepository.UpdateUser(user);

            return _mapper.Map<UserDto>(user);
        }     
        
        public UserDto GetByUserName(string userName)
        {
            var user = _userRepository.GetByEmail(userName);

            return _mapper.Map<UserDto>(user);
        }        
    }
}