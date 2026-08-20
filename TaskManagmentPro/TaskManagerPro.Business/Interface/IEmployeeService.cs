using System;
using System.Collections.Generic;
using System.Text;
using TaskManagmentPro.Contract.Models.Employee;
using TaskManagmentPro.Data.Models;

namespace TaskManagerPro.Business.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(Guid id);

        Task<Employee> AddAsync(AddEmloyee employee);

        Task<Employee> UpdateAsync(Guid id, EditEmployee employee);

        Task<bool> DeleteAsync(Guid Id);
    }
}
