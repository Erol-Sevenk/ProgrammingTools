using Microsoft.AspNetCore.Mvc;
using ErasmusMate.Models;
using System.Linq;
using System;

namespace ErasmusMate.Controllers;

public class ForumController : Controller
{
    private readonly AppDbContext _context;

    public ForumController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var posts = _context.ForumPosts.OrderByDescending(p => p.CreatedAt).ToList();
        return View(posts);
    }
    [HttpPost]
    public IActionResult AddPost(string author, string title, string content)
    {
        if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content))
        {
            var newPost = new ForumPost 
            { 
                Author = string.IsNullOrEmpty(author) ? "Anonymous Student" : author,
                Title = title, 
                Content = content,
                CreatedAt = DateTime.Now
            };
            _context.ForumPosts.Add(newPost);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var post = _context.ForumPosts.Find(id);
        if (post != null)
        {
            _context.ForumPosts.Remove(post);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}