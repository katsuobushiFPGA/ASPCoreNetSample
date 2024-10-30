using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        System.Threading.Tasks.Task AddUserAsync(User user);
        System.Threading.Tasks.Task UpdateUserAsync(User user);
        System.Threading.Tasks.Task DeleteUserAsync(int id);
    }

}
