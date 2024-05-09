using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HtmxTodoApp2024.Models;

public class TodoItem
{
    public int Id { get; set; }
    [Required] public string Text { get; set; } = "";
    public DateTime? Completed { get; set; }
    [Required]
    public TodoItemPriority Priority { get; set; } = TodoItemPriority.Medium;
    [NotMapped] public bool IsCompleted => Completed.HasValue;
}

public enum TodoItemPriority
{
    Low,
    Medium,
    High
}