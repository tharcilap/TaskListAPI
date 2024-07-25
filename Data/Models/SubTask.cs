using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskListAPI.Models
{
	public class SubTask
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        [DisplayName("Sub Task Title")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        [DisplayName("Sub Task Description")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Status")]
        public bool IsComplete { get; set; } = false;

        public int TaskId { get; set; }

        public Task Task { get; set; } = null!;

    }
}

