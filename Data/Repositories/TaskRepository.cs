using System;
using Microsoft.EntityFrameworkCore;
using TaskListAPI.Data;
using TaskListAPI.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskListAPI.Repositories
{
	public class TaskRepository : ITaskRepository
	{
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasksAsync()
        {
            return await _context.Tasks.Include(t => t.SubTasks).ToListAsync();
        }

        public async Task<Models.Task> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.Include(t => t.SubTasks)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Models.Task> GetTaskByTitleAsync(string title)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Title == title);
        }

        public async Task AddTaskAsync(Models.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(Models.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(Models.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}

