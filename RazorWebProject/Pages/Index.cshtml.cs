using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorWebProject.Models;

namespace RazorWebProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public IndexModel(ApplicationContext context)
        {
            _context = context;
        }

        public List<TaskItem> Tasks { get; set; } = new();

        [BindProperty]
        public TaskItem NewTask { get; set; } = new();

        public async Task OnGetAsync()
        {
            Tasks = await _context.Tasks.ToListAsync();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!string.IsNullOrWhiteSpace(NewTask.Title))
            {
                _context.Tasks.Add(NewTask);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}