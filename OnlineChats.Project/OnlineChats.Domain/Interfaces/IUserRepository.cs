using OnlineChats.Domain.Models;

namespace OnlineChats.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task Create(User user);
        public Task<User> Get(string username);
        public Task<IEnumerable<User>> GetAll();
    }
}
