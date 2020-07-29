using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Projects.Commands.AddProject
{
    public class AddProjectCommandValidator : AbstractValidator<AddProjectCommand>
    {
        public AddProjectCommandValidator()
        {
            RuleFor(t => t.Name).NotNull();
            RuleFor(t => t.Description).NotNull();
            RuleFor(t => t.CreatedAt).LessThan(t => t.Deadline);
            RuleFor(t => t.AuthorId).GreaterThan(0);
            RuleFor(t => t.TeamId).GreaterThan(0);
        }
    }
}
