using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Project_mobile_app.Api.Resources.UserResources;

namespace Project_mobile_app.Api.Validators
{
    public class UserSaveResourceValidator : AbstractValidator<UserSaveResource>
    {
        public UserSaveResourceValidator()
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
