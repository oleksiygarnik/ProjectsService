using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Teams.Commands.AddTeam
{
    public class AddTeamCommandValidator :  AbstractValidator<AddTeamCommand>
    {
        public AddTeamCommandValidator()
        {
            RuleFor(t => t.Name).NotNull();
            RuleFor(t => t.CreatedAt).LessThan(t => DateTime.Now);
        }
    }
}
