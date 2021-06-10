using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Project_mobile_app.Api.Resources.UserResources;

namespace Project_mobile_app.Api.Validators
{
    public class UserSaveWithStatResourceValidator : AbstractValidator<UserSaveWithStatResource>
    {
       public UserSaveWithStatResourceValidator()
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

            RuleFor(a => a.Statistics.NumberOfGamesPlayed)
                .NotNull();

            RuleFor(a => a.Statistics.SuccesfullGames)
                .NotNull();

            RuleFor(a => a.Statistics.TimeInGames)
                .NotNull();
        }
    }
}
