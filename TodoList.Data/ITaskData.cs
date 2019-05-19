using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Core;

namespace TodoList.Data
{
    public interface ITaskData
    {
        IEnumerable<Task> GetAll();
        Task Add(Task newTask);
        Task Remove(int removeTaskId);
        Task UpdateStatus(int updateTaskId);
    }
}
