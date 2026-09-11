namespace WorkoutTracker.Web.Models;

public class Workout
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public DateOnly Date {get; set; }

    public ICollection<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>(); 
}