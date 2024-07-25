using System;
using AutoMapper;
using TaskListAPI.Dtos.SubTaskDtos;
using TaskListAPI.Models;

namespace TaskListAPI.Mappers
{
    public class SubTaskProfile : Profile
    {
        public SubTaskProfile()
        {
            CreateMap<SubTask, SubTaskDto>();

            CreateMap<CreateSubTaskDto, SubTask>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Task, opt => opt.Ignore())
            .ForMember(dest => dest.IsComplete, opt => opt.Ignore());

            CreateMap<UpdateSubTaskDto, SubTask>()
            .ForMember(dest => dest.Task, opt => opt.Ignore())
            .ForMember(dest => dest.TaskId, opt => opt.Ignore());

        }
    }
}

