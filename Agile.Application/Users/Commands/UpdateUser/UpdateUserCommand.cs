using Agile.Application.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Users.Commands.UpdateUserCommand
{
    [DataContract]
    public class UpdateUserCommand : IRequest<UserDto>
    {
        [DataMember]
        public int Id { get; set; }

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
