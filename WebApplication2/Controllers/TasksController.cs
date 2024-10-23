using Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var tasks = await _context.Tasks
                .Include(t => t.User) // ユーザー情報も一緒に取得
                .ToListAsync();

            return View(tasks); // ビューにタスクのリストを渡す
        }

    }
}