using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Users.Commands.AddUserCommand
{
    [DataContract]
    public class AddUserCommand : IRequest<int>
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public int? TeamId { get; set; }
    }
}
