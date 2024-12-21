using OnlineChats.Domain.Interfaces;
using OnlineChats.Domain.Models;

namespace OnlineChats.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.Create(user);
        }
        public async Task<User> GetUser(string username)
        {
            var result = await _userRepository.Get(username);
            return result;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var result = await _userRepository.GetAll();
            return result;
        }

    }
}
