using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Htmx;
using HtmxTodoApp2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HtmxTodoApp2024.Pages;

public class IndexModel(ILogger<IndexModel> logger, Database db) : PageModel
{
    public Dictionary<string, IEnumerable<TodoItemViewModel>> Groups = new();

    [BindProperty(Name = "item", SupportsGet = true)]
    public int? Editing { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var all = await db.Items.ToListAsync();
        Groups = new()
        {
            {
                "Pending", all
                    .Where(i => !i.IsCompleted)
                    .OrderByDescending(i => i.Id)
                    .Select(i => new TodoItemViewModel(i, i.Id == Editing))
            },
            {
                "Completed", all
                    .Where(i => i.IsCompleted)
                    .OrderByDescending(i => i.Completed)
                    .Select(i => new TodoItemViewModel(i, i.Id == Editing))
            }
        };

        return Request.IsHtmx()
            ? Partial("_TodoItems", this)
            : Page();
    }

    public async Task<IActionResult> OnPostSave([FromForm]TodoItemSaveModel form)
    {
        var item = form.Id.HasValue
            ? await db.Items.FindAsync(form.Id.Value)
            : (await db.AddAsync(new TodoItem())).Entity;

        item.Completed = form.IsCompleted ? DateTime.UtcNow : null;
        item.Text = form.Text;
        item.Priority = form.Priority;

        await db.SaveChangesAsync();
        
        // process the partial from get
        return await OnGet();
    }

    public async Task<IActionResult> OnPostRemove()
    {
        var item = await db.Items.FindAsync(Editing);
        if (item is not null)
        {
            db.Items.Remove(item);
            await db.SaveChangesAsync();
        }
        return await OnGet();
    }
}

public class TodoItemViewModel(TodoItem item, bool isSelected)
{
    public int Id => item.Id;
    public string Text => item.Text;
    public DateTime? Completed => item.Completed;
    public TodoItemPriority Priority => item.Priority;
    [DisplayName("Complete?")]
    public bool IsCompleted => item.IsCompleted;
    public bool IsSelected => isSelected;

    public string CompletedDisplayText => item.Completed.HasValue
        ? item.Completed.Value.ToString("yyyy MMMM dd")
        : "pending";

    public static IEnumerable<SelectListItem> Priorities { get; } =
        new[] { TodoItemPriority.High, TodoItemPriority.Medium, TodoItemPriority.Low }
            .Select(i => new SelectListItem(i.ToString(), i.ToString()))
            .ToList();
}

public record TodoItemSaveModel(int? Id, string Text, bool IsCompleted, TodoItemPriority Priority);