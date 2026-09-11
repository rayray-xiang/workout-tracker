using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Web.Data;
using WorkoutTracker.Web.Models;

namespace WorkoutTracker.Web.Controllers;

public class ExercisesController : Controller
{
    private readonly AppDbContext _db;

    public ExercisesController(AppDbContext db)
    {
        _db = db;
    }

    // GET: /Exercises
    public async Task<IActionResult> Index()
    {
        var exercises = await _db.Exercises.ToListAsync();
        return View(exercises);
    }

    // GET: /Exercises/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Exercises/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,MuscleGroup,EquipmentType")] Exercise exercise)
    {
        if (ModelState.IsValid)
        {
            _db.Exercises.Add(exercise);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(exercise);
    }
}