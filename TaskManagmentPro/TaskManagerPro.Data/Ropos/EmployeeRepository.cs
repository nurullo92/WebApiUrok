using Microsoft.EntityFrameworkCore;
using TaskManagmentPro.Data.Models;
using TaskManagmentPro.Data.Repositories;

namespace TaskManagmentPro.Data.Ropos
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ContextTaskManager _context;



        public EmployeeRepository(ContextTaskManager context)
        {
            _context = context;
        }


        /// <summary>
        /// Вывести список работников
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }


        //Поиск по Id
        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        /// <summary>
        /// Добавление работника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<Employee> AddAsync(Employee employee)
        {
  
             await _context.Employees.AddAsync(employee);
             await _context.SaveChangesAsync();
                
             return employee;

        }


        /// <summary>
        /// «Обновление информации о работнике
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<Employee> UpdateAsync(Employee employee)
        {

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;

        }

        /// <summary>
        /// Удаляем работников
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync() > 0;


        }
    }
}
