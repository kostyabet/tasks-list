using Microsoft.EntityFrameworkCore;
using TasksList.DataAccess.Entities;

namespace TasksList.DataAccess;

public class TasksListDbContext : DbContext
{
    public TasksListDbContext(DbContextOptions<TasksListDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<TaskEntity> Tasks { get; set; }
}