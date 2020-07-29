using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {

        }
    }
}
