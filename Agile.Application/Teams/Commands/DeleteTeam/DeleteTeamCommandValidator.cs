using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Application.Teams.Commands.DeleteTeam
{
    public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
    {
        public DeleteTeamCommandValidator()
        {
            RuleFor(t => t.Id).GreaterThan(0);
        }
    }
}
