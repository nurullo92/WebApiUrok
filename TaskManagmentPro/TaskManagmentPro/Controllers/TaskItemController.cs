using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPro.Business.Interface;
using TaskManagerPro.Contract.Models.TaskItem;
using TaskManagmentPro.Contract.Models.TaskItem;

namespace TaskManagmentPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        private readonly IMapper _mapper;

        public TaskItemController(
            ITaskItemService taskItemService,
            IMapper mapper)
        {
            _taskItemService = taskItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTaskItem>>> GetAllAsync()
        {
            var taskItems = await _taskItemService.GetAllAsync();

            var result = _mapper.Map<List<GetTaskItem>>(taskItems);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaskItem>> GetByIdAsync(Guid id)
        {
            var taskItem = await _taskItemService.GetByIdAsync(id);

            if (taskItem == null)
                return NotFound();

            var result = _mapper.Map<GetTaskItem>(taskItem);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetTaskItem>> AddAsync(AddTaskItem addTaskItem)
        {

            var taskItem = await _taskItemService.AddAsync(addTaskItem);

            var result = _mapper.Map<GetTaskItem>(taskItem);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskResponse>> UpdateAsync(Guid id, TaskResponse response)
        {
            
            response.Id = id;

            var taskItem = await _taskItemService.UpdateAsync(id, response);

            if (taskItem == null)
                return NotFound();

            var result = _mapper.Map<GetTaskItem>(taskItem);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _taskItemService.DeleteAsync(id);

            return NoContent();
        }
    }
}