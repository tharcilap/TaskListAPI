using System;
using System.Collections.Generic;
using TaskListAPI.Dtos.SubTaskDtos;
using TaskListAPI.Models;

namespace TaskListAPI.Dtos
{
	public class TaskDto
	{
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;
        public int SubTasksCount { get; set; }
        public List<SubTaskDto> SubTasks { get; set; } = new List<SubTaskDto>();
    }
}

