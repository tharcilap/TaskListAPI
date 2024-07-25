using System;
namespace TaskListAPI.Dtos.SubTaskDtos
{
	public class SubTaskDto
	{
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsComplete { get; set; } = false;
        public int TaskId { get; set; }
    }
}

