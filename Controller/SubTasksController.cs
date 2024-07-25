using System;
using Microsoft.AspNetCore.Mvc;
using TaskListAPI.Dtos.SubTaskDtos;

using TaskListAPI.Services;

namespace TaskListAPI.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubTasksController : ControllerBase
	{
        private readonly ISubTaskService _subTaskService;

        public SubTasksController(ISubTaskService subTaskService)
        {
            _subTaskService = subTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubTaskDto>>> GetSubTasks()
		{
            var subTasksDto = await _subTaskService.GetSubTasksAsync();
            return Ok(subTasksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubTaskById(int id)
        {
            try
            {
                var subTaskDto = await _subTaskService.GetSubTaskByIdAsync(id);
                return Ok(subTaskDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateSubtask([FromBody] CreateSubTaskDto createSubTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var subTaskDto = await _subTaskService.CreateSubTaskAsync(createSubTask);
                return CreatedAtAction(nameof(GetSubTaskById), new { id = subTaskDto.Id }, subTaskDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Task Not Found" });
            }
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateSubTask(int id, [FromBody] UpdateSubTaskDto updateSubTaskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _subTaskService.UpdateSubTaskAsync(id, updateSubTaskDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                await _subTaskService.DeleteSubTaskAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

