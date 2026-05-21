using Microsoft.AspNetCore.Mvc;
using ErasmusMate.Models;
using System.Linq;

namespace ErasmusMate.Controllers;

public class CoursesController : Controller
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var courses = _context.Courses.ToList();
        return View(courses);
    }

    [HttpPost]
    public IActionResult AddCourse(string hostCourseName, string homeCourseName, int ects)
    {
        if (!string.IsNullOrEmpty(hostCourseName) && !string.IsNullOrEmpty(homeCourseName))
        {
            var newCourse = new Course 
            { 
                HostCourseName = hostCourseName, 
                HomeCourseName = homeCourseName, 
                Ects = ects,
                IsApproved = false 
            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var course = _context.Courses.Find(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}