using AutoMapper;
using TaskManagerPro.Business.Interface;
using TaskManagerPro.Contract.Models.TaskItem;
using TaskManagerPro.Data.Ropos;
using TaskManagmentPro.Contract.Models.TaskItem;
using TaskManagmentPro.Data.Models;

namespace TaskManagerPro.Business.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _repository;
        private readonly IMapper _mapper;

        public TaskItemService(
            ITaskItemRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id не может быть пустым.");

            return await _repository.GetByIdAsync(id);
        }

        public async Task<TaskItem> AddAsync(AddTaskItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrWhiteSpace(item.Title))
                throw new ArgumentException("Название обязательно.");

            var taskItem = _mapper.Map<TaskItem>(item);

            return await _repository.AddAsync(taskItem);
        }

        public async Task<TaskItem> UpdateAsync(Guid id, TaskResponse item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var existingTaskItem = await _repository.GetByIdAsync(id);

            if (existingTaskItem == null)
                throw new KeyNotFoundException("Сотрудник не найден.");

            existingTaskItem.Title = item.Title;
            existingTaskItem.Description = item.Description;

            return await _repository.UpdateAsync(existingTaskItem);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id не может быть пустым.");

            var taskItem = await _repository.GetByIdAsync(id);

            if (taskItem == null)
                throw new ArgumentException("Задача не найдена.");

            return await _repository.DeleteAsync(taskItem);
        }
    }
}