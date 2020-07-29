using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
