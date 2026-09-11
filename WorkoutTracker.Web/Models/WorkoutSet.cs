using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WorkoutTracker.Web.Models;

public class WorkoutSet
{
    public int Id { get; set; }

    [Required]
    public int Reps { get; set; }
    
    [Required]
    public decimal Weight { get; set; }

    public int ExerciseId { get; set; }
    [ValidateNever]
    public Exercise Exercise { get; set; } = null!;

    public int WorkoutId { get; set; }
    [ValidateNever]
    public Workout Workout { get; set; } = null!;    
}