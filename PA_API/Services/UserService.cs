using AutoMapper;
using PA.Core.Contracts.Repositories;
using PA_API.Exceptions;
using PA_API.Models.User;

namespace PA_API.Services
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

        public UserViewModel Login(string username, string password)
        {
            var user = _userRepository.GetByUserName(username);

            if (user == null)
                throw new InvalidLoginOrPasswordException();

            var encodedPassword = PasswordHasher.HashPassword(password);

            if (encodedPassword != user.Password)
                throw new InvalidLoginOrPasswordException();

            return _mapper.Map<UserViewModel>(user);
        }

        public UserViewModel UpdateUser(UserViewModel userViewModel)
        {
            var user = _userRepository.Get(userViewModel.Id);

            user.Password = PasswordHasher.HashPassword(userViewModel.Password);
            user.Role = user.Role;

            user = _userRepository.UpdateUser(user);

            return _mapper.Map<UserViewModel>(user);
        }     
        
        public UserViewModel GetByUserName(string userName)
        {
            var user = _userRepository.GetByUserName(userName);

            return _mapper.Map<UserViewModel>(user);
        }        
    }
}