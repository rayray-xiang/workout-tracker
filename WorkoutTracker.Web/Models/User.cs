using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Web.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Weight { get; set; }
    
    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}