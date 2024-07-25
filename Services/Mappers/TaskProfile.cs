using System;
using AutoMapper;
using TaskListAPI.Dtos;
using TaskListAPI.Dtos.TaskDtos;

namespace TaskListAPI.Mappers
{
	public class TaskProfile : Profile
	{
		public TaskProfile()
		{
            CreateMap<Models.Task, TaskDto>()
            .ForMember(dest => dest.SubTasksCount, opt => opt.MapFrom(src => src.SubTasks.Count))
            .ForMember(dest => dest.SubTasks, opt => opt.MapFrom(src => src.SubTasks));

            CreateMap<CreateTaskDto, Models.Task>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.IsComplete, opt => opt.Ignore());

            CreateMap<UpdateTaskDto, Models.Task>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Task, TaskDto>();
        }
	}
}

