using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskCommandValidator()
        {
            RuleFor(t => t.Id).GreaterThan(0);
        }
    }
}
