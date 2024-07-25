using System;
using TaskListAPI.Dtos.SubTaskDtos;

namespace TaskListAPI.Services
{
	public interface ISubTaskService
	{
        Task<IEnumerable<SubTaskDto>> GetSubTasksAsync();
        Task<SubTaskDto> GetSubTaskByIdAsync(int id);
        Task<SubTaskDto> CreateSubTaskAsync(CreateSubTaskDto createSubTaskDto);
        Task UpdateSubTaskAsync(int id, UpdateSubTaskDto updateSubTaskDto);
        Task DeleteSubTaskAsync(int id);
    }
}

