using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {

        }
    }
}
