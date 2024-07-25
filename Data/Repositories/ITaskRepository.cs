using System;
using TaskListAPI.Models;
using Task = System.Threading.Tasks.Task;


namespace TaskListAPI.Repositories
{
	public interface ITaskRepository
	{
        Task<IEnumerable<Models.Task>> GetAllTasksAsync();
        Task<Models.Task> GetTaskByIdAsync(int id);
        Task<Models.Task> GetTaskByTitleAsync(string title);
        Task AddTaskAsync(Models.Task task);
        Task UpdateTaskAsync(Models.Task task);
        Task DeleteTaskAsync(Models.Task task);
    }
}

