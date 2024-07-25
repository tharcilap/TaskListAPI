using System;
using TaskListAPI.Dtos;
using TaskListAPI.Dtos.TaskDtos;

namespace TaskListAPI.Services
{
	public interface ITaskService
	{
        Task<IEnumerable<TaskDto>> GetTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task<TaskDto>CreateTaskAsync(CreateTaskDto createTaskDto);
        Task UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto);
        Task DeleteTaskAsync(int id);
    }
}

