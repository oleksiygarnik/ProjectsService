using Agile.Application.Tasks.Queries.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Tasks.Queries
{
    [DataContract]
    public class TasksByPerformerIdFilterQuery : IRequest<IEnumerable<TaskShortInformationDto>>
    {
        public int Id { get; set; }
    }
}
