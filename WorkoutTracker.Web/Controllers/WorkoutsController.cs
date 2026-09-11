using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Web.Data;
using WorkoutTracker.Web.Models;

namespace WorkoutTracker.Web.Controllers;

public class WorkoutsController : Controller
{
    private readonly AppDbContext _db;
    public WorkoutsController(AppDbContext db)
    {
        _db = db;
    }

    // GET: /Workouts
    public async Task<IActionResult> Index()
    {
        var workouts = await _db.Workouts.OrderByDescending(w => w.Date).ToListAsync();
        return View(workouts);
    }

    // GET: /Workouts/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Workouts/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Date")] Workout workout)
    {
        if (ModelState.IsValid)
        {
            workout.UserId = 1; // Hardcode as 1 since I'm the only user for now
            _db.Workouts.Add(workout);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(workout);
    }

    // DELETE: /Workouts/Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var workout = await _db.Workouts.FindAsync(id);
        if (workout != null)
        {
            _db.Workouts.Remove(workout);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}