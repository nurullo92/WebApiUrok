using System;
using System.Collections.Generic;
using System.Text;
using TaskManagmentPro.Data.Models;

namespace TaskManagerPro.Data.Ropos
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<TaskItem> AddAsync(TaskItem item);
        Task<TaskItem> UpdateAsync(TaskItem item);
        Task<bool> DeleteAsync(TaskItem item);
    }
}
