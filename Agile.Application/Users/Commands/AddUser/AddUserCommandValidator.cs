using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Users.Commands.AddUserCommand
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.Birthday).LessThan(t => DateTime.Now);
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.TeamId).GreaterThan(0);
        }
    }
}
