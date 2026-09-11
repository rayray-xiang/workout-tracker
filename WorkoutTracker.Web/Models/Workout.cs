using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WorkoutTracker.Web.Models;

public class Workout
{
    public int Id { get; set; }

    public int UserId { get; set; }
    [ValidateNever]
    public User User { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateOnly Date {get; set; }

    public ICollection<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>(); 
}