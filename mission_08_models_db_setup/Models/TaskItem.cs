using System.ComponentModel.DataAnnotations;

namespace mission_08_models_db_setup.Models;

public class TaskItem
{
    public int TaskItemId { get; set; }
    
    [Required]
    public string Task { get; set; } = string.Empty;
    
    public DateTime? DueDate { get; set; }
    
    [Required]
    [Range(1, 4)]
    public int Quadrant { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
    
    public Category? Category { get; set; }
    
    public bool Completed { get; set; }
}
