using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Agile.Application.Users.Queries
{
    [DataContract]
    public class UsersOrderingQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
