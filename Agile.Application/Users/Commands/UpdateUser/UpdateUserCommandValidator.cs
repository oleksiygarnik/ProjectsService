using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Id).GreaterThan(0);
            RuleFor(u => u.TeamId).GreaterThan(0);
        }
    }
}
