using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Web.Models;

public class Exercise
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(50)]
    public string? MuscleGroup { get; set; }

    [StringLength(50)]
    public string? EquipmentType { get; set; }

    public ICollection<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>();
}