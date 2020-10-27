using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Data.DTOs;

namespace Codexoft.CrossLib.WebTemplate.Data
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDto>(); // means you want to map from User to UserDTO
        }
    }
}
