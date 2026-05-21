using Microsoft.AspNetCore.Mvc;
using ErasmusMate.Models;
using System.Linq;

namespace ErasmusMate.Controllers;

public class AccommodationsController : Controller
{
    private readonly AppDbContext _context;

    public AccommodationsController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var listings = _context.Accommodations.ToList();
        return View(listings);
    }

    [HttpPost]
    public IActionResult Add(string title, string description, decimal price, string location, string contactInfo)
    {
        if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(location))
        {
            var newListing = new Accommodation 
            { 
                Title = title, 
                Description = description, 
                Price = price,
                Location = location,
                ContactInfo = contactInfo
            };
            _context.Accommodations.Add(newListing);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var listing = _context.Accommodations.Find(id);
        if (listing != null)
        {
            _context.Accommodations.Remove(listing);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}