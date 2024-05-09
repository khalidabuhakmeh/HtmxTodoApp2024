using Microsoft.EntityFrameworkCore;

namespace HtmxTodoApp2024.Models;

public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    public DbSet<TodoItem> Items => Set<TodoItem>();
}