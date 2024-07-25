using System;
using TaskListAPI.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskListAPI.Repositories
{
	public interface ISubTaskRepository
	{
        Task<IEnumerable<SubTask>> GetAllSubTasksAsync();
        Task<SubTask> GetSubTaskByIdAsync(int id);
        Task AddSubTaskAsync(SubTask subTask);
        Task UpdateSubTaskAsync(SubTask subTask);
        Task DeleteSubTaskAsync(SubTask subTask);
    }
}

