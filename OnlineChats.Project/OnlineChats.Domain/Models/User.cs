namespace OnlineChats.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public static User CreateUser(int id, string username, string email, string password)
        {
            return new User()
            {
                Id = id,
                Username = username,
                Email = email,
                Password = password
            };
        }
    }
}
