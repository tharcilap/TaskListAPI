using System;
using Microsoft.EntityFrameworkCore;
using TaskListAPI.Models;

namespace TaskListAPI.Data
{
	public class TaskContext : DbContext
	{
		public TaskContext(DbContextOptions<TaskContext> options)
			: base(options){ }

		public DbSet<Models.Task> Tasks { get; set; }
		public DbSet<SubTask> SubTasks { get; set; }


        // Configure the one-to-many relationship between Task and SubTask
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Task>()
                .HasMany(t => t.SubTasks)  
                .WithOne(st => st.Task) 
                .HasForeignKey(st => st.TaskId);  

        }
    }
}

