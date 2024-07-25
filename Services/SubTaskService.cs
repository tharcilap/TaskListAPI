using System;
using AutoMapper;
using TaskListAPI.Dtos.SubTaskDtos;
using TaskListAPI.Models;
using TaskListAPI.Repositories;
using Task = System.Threading.Tasks.Task;

namespace TaskListAPI.Services
{
	public class SubTaskService :ISubTaskService
	{
        private readonly ISubTaskRepository _subTaskRepository;
        private readonly IMapper _mapper;

        public SubTaskService(ISubTaskRepository subTaskRepository, IMapper mapper)
        {
            _subTaskRepository = subTaskRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SubTaskDto>> GetSubTasksAsync()
        {
            var subTasks = await _subTaskRepository.GetAllSubTasksAsync();
            return _mapper.Map<IEnumerable<SubTaskDto>>(subTasks);
        }

        public async Task<SubTaskDto> GetSubTaskByIdAsync(int id)
        {
            var subTask = await _subTaskRepository.GetSubTaskByIdAsync(id);
            if (subTask == null)
            {
                throw new KeyNotFoundException("SubTask not found.");
            }
            return _mapper.Map<SubTaskDto>(subTask);
        }

        public async Task<SubTaskDto> CreateSubTaskAsync(CreateSubTaskDto createSubTaskDto)
        {
            var subTask = _mapper.Map<SubTask>(createSubTaskDto);
            await _subTaskRepository.AddSubTaskAsync(subTask);
            return _mapper.Map<SubTaskDto>(subTask);
        }

        public async Task UpdateSubTaskAsync(int id, UpdateSubTaskDto updateSubTaskDto)
        {
            var subTask = await _subTaskRepository.GetSubTaskByIdAsync(id);
            if (subTask == null)
            {
                throw new KeyNotFoundException("SubTask not found.");
            }

            _mapper.Map(updateSubTaskDto, subTask);
            await _subTaskRepository.UpdateSubTaskAsync(subTask);
        }

        public async Task DeleteSubTaskAsync(int id)
        {
            var subTask = await _subTaskRepository.GetSubTaskByIdAsync(id);
            if (subTask == null)
            {
                throw new KeyNotFoundException("SubTask not found.");
            }

            await _subTaskRepository.DeleteSubTaskAsync(subTask);
        }

    }
}

