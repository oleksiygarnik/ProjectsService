using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator()
        {
            RuleFor(t => t.Id).GreaterThan(0);
            RuleFor(t => t.Name).NotEmpty();
        }
    }
}
