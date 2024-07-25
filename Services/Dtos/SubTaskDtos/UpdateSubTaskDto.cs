using System;
using System.ComponentModel.DataAnnotations;

namespace TaskListAPI.Dtos.SubTaskDtos
{
	public class UpdateSubTaskDto
	{
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string? Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string? Description { get; set; } = string.Empty;

        public bool? IsComplete { get; set; }
    }
}

