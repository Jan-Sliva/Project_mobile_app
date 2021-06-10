using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Project_mobile_app.Api.Resources.AdminResources;

namespace Project_mobile_app.Api.Validators
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
