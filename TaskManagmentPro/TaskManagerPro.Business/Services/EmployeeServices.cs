using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskManagerPro.Business.Interface;
using TaskManagmentPro.Contract.Models.Employee;
using TaskManagmentPro.Data.Models;
using TaskManagmentPro.Data.Repositories;

namespace TaskManagerPro.Business.Services
{
    public class EmployeeServices : IEmployeeService
    {

        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeServices(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        /// <summary>
        /// Получает список всех сотрудников.
        /// Если сотрудники отсутствуют, генерирует исключение.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        /// <exception cref="InvalidOperationException">
        /// Возникает, если список сотрудников пуст.
        /// </exception>
        public async Task<List<Employee>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();

            if (!employees.Any())
                throw new InvalidOperationException("Список сотрудников пуст.");

            return employees;
        }

        /// <summary>
        /// Получает сотрудника по идентификатору.
        /// Проверяет корректность переданного идентификатора.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Найденный сотрудник или null.</returns>
        /// <exception cref="ArgumentException">
        /// Возникает, если передан некорректный идентификатор.
        /// </exception>
        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        /// <summary>
        /// Добавляет нового сотрудника.
        /// Проверяет обязательность заполнения имени.
        /// </summary>
        /// <param name="employee">Данные сотрудника.</param>
        /// <returns>Добавленный сотрудник.</returns>
        /// <exception cref="ArgumentException">
        /// Возникает, если имя сотрудника не заполнено.
        /// </exception>
        public async Task<Employee> AddAsync(AddEmloyee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Name))
                throw new ArgumentException("Имя сотрудника обязательно.");
            var employees = _mapper.Map<Employee>(employee);
            return await _repository.AddAsync(employees);
        }



        public async Task<Employee> UpdateAsync(Guid id, EditEmployee model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var existingEmployee = await _repository.GetByIdAsync(id);

            if (existingEmployee == null)
                throw new KeyNotFoundException("Сотрудник не найден.");

            existingEmployee.Name = model.Name;
            existingEmployee.Email = model.Email;
            existingEmployee.Phone = model.Phone;

            return await _repository.UpdateAsync(existingEmployee);
        }



        /// <summary>
        /// Удаляет сотрудника по идентификатору.
        /// Проверяет существование сотрудника перед удалением.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>
        /// True, если сотрудник успешно удалён; иначе генерируется исключение.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Возникает, если сотрудник не найден.
        /// </exception>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                throw new ArgumentException("Сотрудник не найден.");

            return await _repository.DeleteAsync(employee);
        }
    }
}