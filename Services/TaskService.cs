using System;
using AutoMapper;
using TaskListAPI.Dtos;
using TaskListAPI.Dtos.TaskDtos;
using TaskListAPI.Repositories;

namespace TaskListAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException("Task not found.");
            }
            return _mapper.Map<TaskDto>(task);
        }

        public async Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto)
        {
            var existingTask = await _taskRepository.GetTaskByTitleAsync(createTaskDto.Title);
            if (existingTask != null)
            {
                throw new Exception("A task with the same name already exists. Please choose a different title.");
            }

            var task = _mapper.Map<Models.Task>(createTaskDto);
            await _taskRepository.AddTaskAsync(task);
            return _mapper.Map<TaskDto>(task);
        }

        public async Task UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException("Task not found.");
            }

            bool taskDtoIsCompleteHasValue = updateTaskDto.IsComplete.HasValue;
            bool taskDtoIsCompleteValue = updateTaskDto.IsComplete.Value;
            bool hasIncompleteSubtasks = task.SubTasks.Any(st => !st.IsComplete);

            if (taskDtoIsCompleteHasValue && taskDtoIsCompleteValue && hasIncompleteSubtasks)
            {
                throw new InvalidOperationException("All sub tasks must be complete before marking the task as complete.");
            }

            _mapper.Map(updateTaskDto, task);
            await _taskRepository.UpdateTaskAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                throw new KeyNotFoundException("Task not found.");
            }

            if (task.SubTasks.Any())
            {
                throw new InvalidOperationException("Can't delete task with existing Subtasks.");
            }

            await _taskRepository.DeleteTaskAsync(task);
        }
    }
}

