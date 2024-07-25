using System;
using System.ComponentModel.DataAnnotations;

namespace TaskListAPI.Dtos.SubTaskDtos
{
	public class CreateSubTaskDto
	{
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "TaskId is required.")]
        public int TaskId { get; set; }
    }
}

