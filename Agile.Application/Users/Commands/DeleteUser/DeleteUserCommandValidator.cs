using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Users.Commands.DeleteUserCommand
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(u => u.Id).GreaterThan(0);
        }
    }
}
