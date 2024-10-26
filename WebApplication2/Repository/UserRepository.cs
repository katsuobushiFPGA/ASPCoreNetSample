using Context;
using Dapper;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var sql = "SELECT * FROM users";
            return await _context.Connection.QueryAsync<User>(sql);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var sql = "SELECT * FROM users WHERE Id = @Id";
            return await _context.Connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async System.Threading.Tasks.Task AddUserAsync(User user)
        {
            var sql = "INSERT INTO users (username, email) VALUES (@username, @email)";
            await _context.Connection.ExecuteAsync(sql, user);
        }

        public async System.Threading.Tasks.Task UpdateUserAsync(User user)
        {
            var sql = "UPDATE users SET username = @username, email = @email WHERE Id = @Id";
            await _context.Connection.ExecuteAsync(sql, user);
        }

        public async System.Threading.Tasks.Task DeleteUserAsync(int id)
        {
            var sql = "DELETE FROM users WHERE Id = @Id";
            await _context.Connection.ExecuteAsync(sql, new { Id = id });
        }
    }

}
