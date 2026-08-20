using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagmentPro.Contract.Models.Employee;

namespace TaskManagerPro.Contract.Validation
{
    public class AddEmployeeValidation : AbstractValidator<EditEmployee>
    {
        public AddEmployeeValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Имя обязателен");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Введите корректный email");

            RuleFor(x => x.Phone)
                .Matches(@"^\+?[0-9]{9,15}$").WithMessage("Введите корректный номер телефона");
        }
    }
}
