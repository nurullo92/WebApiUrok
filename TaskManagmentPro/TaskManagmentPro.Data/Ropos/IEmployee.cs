using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagmentPro.Data.Models;

namespace TaskManagmentPro.Data.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();

        Task<Employee> GetByIdAsync(Guid id);

        Task<Employee> AddAsync(Employee employee);

        Task<Employee> UpdateAsync(Employee employee);

        Task<bool> DeleteAsync(Guid id);
    }
}