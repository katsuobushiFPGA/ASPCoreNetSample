using Microsoft.AspNetCore.Mvc;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: users
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetUsersAsync();
            return View(users); // ビューにタスクのリストを渡す
        }

    }
}