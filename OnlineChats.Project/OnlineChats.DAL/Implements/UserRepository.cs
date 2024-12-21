using Serilog;
using Dapper;
using OnlineChats.Domain.Interfaces;
using OnlineChats.Domain.Models;
using Npgsql;

namespace OnlineChats.DAL.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionString _connectionString;
        private readonly ILogger _logger;

        public UserRepository(ILogger logger, IConnectionString connectionString)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task Create(User user)
        {
            try
            {
               using(var connection = new NpgsqlConnection(_connectionString.ConnectionString))
               {
                    await connection.OpenAsync();

                    var query = 
                        @"INSERT INTO ""User"" (username, email, password)
                        VALUES (@Username, @Email, @Password)";

                    await connection.ExecuteAsync(query, user);
                    _logger.Information($"Пользователь [{user.Id} - {user.Username}] успешно добавлен");
               } 
            }
            catch(Exception ex)
            {
                _logger.Error("Ошибка создания пользователя", ex.Message);
                throw;
            }
        }

        public async Task<User> Get(string username)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString.ConnectionString))
                {
                    await connection.OpenAsync();

                    var query =
                        @"SELECT * FROM ""User""
                        WHERE username = @username";

                    var result = await connection.QueryFirstAsync<User>(query, new { username });
                    _logger.Information($"Пользователь {username} успешно найден");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка получения пользователя", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString.ConnectionString))
                {
                    await connection.OpenAsync();

                    var query = 
                        @"SELECT * FROM ""User""";

                    var result = await connection.QueryAsync<User>(query);
                    _logger.Information("Пользователи найдены");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Ошибка получения пользователей", ex.Message);
                throw;
            }
        }
    }
}
