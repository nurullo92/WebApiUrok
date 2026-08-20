using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPro.Business.Interface;
using TaskManagmentPro.Contract.Models.Employee;
using TaskManagmentPro.Data.Models;

namespace TaskManagmentPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(
            IEmployeeService employeeService,
            IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<List<GetEmployee>>> GetAllAsync()
        {
            var employees = await _employeeService.GetAllAsync();

            var result = _mapper.Map<List<GetEmployee>>(employees);

            return Ok(result);
        }

        // GET: api/Employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployee>> GetByIdAsync(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            var result = _mapper.Map<GetEmployee>(employee);

            return Ok(result);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<GetEmployee>> AddAsync(AddEmloyee model)
        {
            var createdEmployee = await _employeeService.AddAsync(model);

            var result = _mapper.Map<GetEmployee>(createdEmployee);

            return Ok(result);
        }

        // PUT: api/Employee/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<GetEmployee>> UpdateAsync(
        Guid id,
        EditEmployee model)
        {
            var updatedEmployee =
                await _employeeService.UpdateAsync(id, model);

            var result = _mapper.Map<GetEmployee>(updatedEmployee);

            return Ok(result);
        }

        // DELETE: api/Employee/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}