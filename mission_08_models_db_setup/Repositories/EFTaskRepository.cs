using Microsoft.EntityFrameworkCore;
using mission_08_models_db_setup.Data;
using mission_08_models_db_setup.Models;

namespace mission_08_models_db_setup.Repositories;

public class EFTaskRepository : ITaskRepository
{
    private readonly QuadrantsContext _context;

    public EFTaskRepository(QuadrantsContext context)
    {
        _context = context;
    }

    public IEnumerable<TaskItem> GetAllTasks()
    {
        return _context.Tasks.Include(t => t.Category).ToList();
    }

    public TaskItem? GetTaskById(int id)
    {
        return _context.Tasks.Include(t => t.Category).FirstOrDefault(t => t.TaskItemId == id);
    }

    public void AddTask(TaskItem task)
    {
        _context.Tasks.Add(task);
    }

    public void UpdateTask(TaskItem task)
    {
        _context.Tasks.Update(task);
    }

    public void DeleteTask(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
