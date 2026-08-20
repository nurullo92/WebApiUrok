using TaskManagerPro.Contract.Models.TaskItem;
using TaskManagmentPro.Contract.Models.TaskItem;
using TaskManagmentPro.Data.Models;

namespace TaskManagerPro.Business.Interface
{
    public interface ITaskItemService
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<TaskItem> AddAsync(AddTaskItem item);
        Task<TaskItem> UpdateAsync(Guid id, TaskResponse item);
        Task<bool> DeleteAsync(Guid id);
    }
}