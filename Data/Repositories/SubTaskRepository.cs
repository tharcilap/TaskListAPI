using System;
using Microsoft.EntityFrameworkCore;
using TaskListAPI.Data;
using TaskListAPI.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskListAPI.Repositories
{
	public class SubTaskRepository : ISubTaskRepository
	{
        private readonly TaskContext _context;

        public SubTaskRepository(TaskContext context)
		{
            _context = context;
        }

        public async Task<IEnumerable<SubTask>> GetAllSubTasksAsync()
        {
            return await _context.SubTasks.ToListAsync();
        }

        public async Task<SubTask> GetSubTaskByIdAsync(int id)
        {
            return await _context.SubTasks.FindAsync(id);
        }

        public async Task AddSubTaskAsync(SubTask subTask)
        {
            await _context.SubTasks.AddAsync(subTask);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubTaskAsync(SubTask subTask)
        {
            _context.SubTasks.Update(subTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubTaskAsync(SubTask subTask)
        {
            _context.SubTasks.Remove(subTask);
            await _context.SaveChangesAsync();
        }
    }
}

