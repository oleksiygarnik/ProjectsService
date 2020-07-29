using Agile.Application.Users.Commands.AddUserCommand;
using Agile.Application.Users.Queries;
using Agile.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Infrastructure.QueryHandlers.Users
{
    public class UserDtoMapper : Profile
    {
        public UserDtoMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<AddUserCommand, User>();
        }
    }
}
