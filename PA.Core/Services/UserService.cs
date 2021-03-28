using PA_API.Exceptions;
using PA_API.Models.User;
using PA_API.Repositories;

namespace PA_API.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel Login(string username, string password)
        {
            var user = _userRepository.GetByUserName(username);

            if (user == null)
                throw new InvalidLoginOrPasswordException();

            var encodedPassword = PasswordHasher.HashPassword(password);

            if (encodedPassword != user.Password)
                throw new InvalidLoginOrPasswordException();

            return user;
        }

        public UserViewModel UpdateUser(UserViewModel user)
        {
            return _userRepository.UpdateUser(user);
        }     
        
        public UserViewModel GetByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }        
    }
}