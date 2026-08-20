using AutoMapper;
using TaskManagerPro.Contract.Models.TaskItem;
using TaskManagmentPro.Contract.Models.Employee;
using TaskManagmentPro.Contract.Models.TaskItem;
using TaskManagmentPro.Data.Models;

namespace TaskManagmentPro
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //Employee
            CreateMap<AddEmloyee, Employee>();  
            CreateMap<EditEmployee, Employee>();  
            CreateMap<Employee, GetEmployee>();


            //TaskItem
            CreateMap<AddTaskItem, TaskItem>();
            CreateMap<TaskResponse, TaskItem>();
            CreateMap<TaskItem, GetTaskItem>();
        }
    }
}
