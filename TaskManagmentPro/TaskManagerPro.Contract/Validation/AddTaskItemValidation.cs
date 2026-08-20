using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagerPro.Contract.Models.TaskItem;

namespace TaskManagerPro.Contract.Validation
{
    public class AddTaskItemValidation : AbstractValidator<TaskResponse>
    {

        public AddTaskItemValidation()
        {
            RuleFor(s => s.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(50);
        }
    }
}
