using HomeWork49.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork49.Controllers;

public class AnimalController : Controller
{
    private AnimalContext _context;

    public AnimalController(AnimalContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        var animals = _context.Animals.ToList();
        return View(animals);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Animal animal)
    {
        if (animal != null)
        {
            _context.Add(animal);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    
    public IActionResult Details(int id)
    {
        var animal = _context.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }

        return View(animal);
    }
}