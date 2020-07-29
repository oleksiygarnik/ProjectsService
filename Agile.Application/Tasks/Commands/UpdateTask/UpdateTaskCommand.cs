using Agile.Application.Tasks.Queries;
using Agile.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Tasks.Commands.UpdateTask
{
    [DataContract]
    public class UpdateTaskCommand : IRequest<TaskDto>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public DateTime FinishedAt { get; set; }

        [DataMember]
        public TaskState TaskState { get; set; }

        [DataMember]
        public int ProjectId { get; set; }

        [DataMember]
        public int PerformerId { get; set; }
    }
}
