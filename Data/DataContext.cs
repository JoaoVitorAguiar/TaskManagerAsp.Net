using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data;

public class DataContext : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; }  
    public DataContext(DbContextOptions options) : base(options)
    {
    }
}
