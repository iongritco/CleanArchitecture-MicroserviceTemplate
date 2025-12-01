using MicroserviceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceTemplate.Persistence;

public class ToDoDataContext : DbContext
{
    public ToDoDataContext(DbContextOptions<ToDoDataContext> options)
        : base(options)
    {
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }
}
