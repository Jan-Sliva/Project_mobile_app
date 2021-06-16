using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Api.Resources.AdminResources;

namespace Api.Validators
{
    public class AdminSaveResourceValidator : AbstractValidator<AdminSaveResource>
    {
        public AdminSaveResourceValidator()
        {
            RuleFor(a => a.UserName)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(a => a.Password)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(a => a.Email)
                .NotEmpty()
                .MaximumLength(320);
        }
    }
}
