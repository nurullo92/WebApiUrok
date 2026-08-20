
using System;
using Microsoft.EntityFrameworkCore;
using TaskManagmentPro.Data;
using TaskManagmentPro.Data.Models;

namespace TaskManagerPro.Data.Ropos
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ContextTaskManager _context;

        public TaskItemRepository(ContextTaskManager context) 
        {
            _context = context;
        }


        //Вывод список задач.
        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }

        //Поиск задачи по Id
        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _context.TaskItems.FindAsync(id);       
        }


        //Добавление задачи
        public async Task<TaskItem> AddAsync(TaskItem item)
        {
            await _context.TaskItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        //Изменение задачи
        public async Task<TaskItem> UpdateAsync(TaskItem item)
        {
             _context.TaskItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }


        //Удаление задачи
        public async Task<bool> DeleteAsync(TaskItem item)
        {
             _context.TaskItems.Remove(item);
            return await _context.SaveChangesAsync() > 0;
             
        }


    }
}
