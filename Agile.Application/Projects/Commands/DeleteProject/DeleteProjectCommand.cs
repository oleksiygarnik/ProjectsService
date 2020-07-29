using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Projects.Commands.DeleteProject
{
    [DataContract]
    public class DeleteProjectCommand : IRequest
    {
        public int Id { get; set; }
    }
}
