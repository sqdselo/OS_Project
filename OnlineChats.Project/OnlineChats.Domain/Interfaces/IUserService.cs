using OnlineChats.Domain.Models;

namespace OnlineChats.Domain.Interfaces
{
    public interface IUserService
    {
        public Task CreateUser(User user);
        public Task<User> GetUser(string username);
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
