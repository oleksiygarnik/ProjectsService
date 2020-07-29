using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Tasks.Commands.DeleteTask
{
    [DataContract]
    public class DeleteTaskCommand : IRequest
    {
        public int Id { get; set; }
    }
}
