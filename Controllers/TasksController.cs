using Microsoft.AspNetCore.Mvc;
using ErasmusMate.Models;
using System.Linq;

namespace ErasmusMate.Controllers;

public class TasksController : Controller
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var tasks = _context.ErasmusTasks.ToList();
        return View(tasks);
    }
    [HttpPost]
    public IActionResult AddTask(string title)
    {
        if (!string.IsNullOrEmpty(title))
        {
            var newTask = new ErasmusTask { Title = title, IsCompleted = false };
            _context.ErasmusTasks.Add(newTask);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
[HttpPost]
public async Task<IActionResult> Complete(int id)
{
    var task = await _context.ErasmusTasks.FindAsync(id);
    
    if (task != null)
    {
        task.IsCompleted = true; 
        
        await _context.SaveChangesAsync();
    }
    
    return RedirectToAction(nameof(Index));
}
}