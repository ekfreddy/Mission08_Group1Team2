using mission_08_models_db_setup.Models;

namespace mission_08_models_db_setup.Repositories;

public interface ITaskRepository
{
    IEnumerable<TaskItem> GetAllTasks();
    TaskItem? GetTaskById(int id);
    void AddTask(TaskItem task);
    void UpdateTask(TaskItem task);
    void DeleteTask(int id);
    void SaveChanges();
}
