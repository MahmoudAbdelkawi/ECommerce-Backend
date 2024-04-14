using AutoMapper;
using ECommerce.Core.Features.Authentication.Command.Dtos;
using ECommerce.Core.Mapper.MapperDtos;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, SignupDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
