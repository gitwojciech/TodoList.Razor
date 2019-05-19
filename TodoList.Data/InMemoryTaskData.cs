using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Core;
using System.Linq;

namespace TodoList.Data
{
    public class InMemoryTaskData : ITaskData
    {
        readonly List<Task> tasks;

        public InMemoryTaskData()
        {
            tasks = new List<Task>()
            {
                new Task { Id= 1, Description="Call Mum",Status=false},
                new Task { Id= 2, Description="Book holidays",Status=true},
            };
        }

        public Task Add(Task newTask)
        {
            if (newTask != null)
            {
                tasks.Add(newTask);
                newTask.Id = tasks.Max(r => r.Id) + 1;
                newTask.Status = false;
            }
            return newTask;
        }

        public IEnumerable<Task> GetAll()
        {
            return tasks.OrderByDescending(r=>r.Description);
        }

        public Task Remove(int removeTaskId)
        {
            Task task = tasks.SingleOrDefault(r => r.Id == removeTaskId);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return task;
        }

        public Task UpdateStatus(int updateTaskId)
        {
            Task task = tasks.SingleOrDefault(r => r.Id == updateTaskId);
            if (task != null)
            {
                task.Status = !task.Status;
            }
            return task;

        }
    }
}
