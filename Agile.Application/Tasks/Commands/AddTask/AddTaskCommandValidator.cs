using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Tasks.Commands.AddTask
{
    public class AddTaskCommandValidator : AbstractValidator<AddTaskCommand>
    {
        public AddTaskCommandValidator()
        {
            RuleFor(t => t.Name).NotNull();
            RuleFor(t => t.Description).NotNull();
            RuleFor(t => t.CreatedAt).LessThan(t => t.FinishedAt);
            RuleFor(t => t.PerformerId).GreaterThan(0);
            RuleFor(t => t.ProjectId).GreaterThan(0);
        }
    }
}
