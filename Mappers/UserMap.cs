using AutoMapper;
using KMA.DTOS.UsersDTO;
using KMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Mappers
{
    public class UserMap: Profile
    {
        public UserMap()
        {
            CreateMap<UserDTO, User>()
                .ForMember(d => d.Name, source => source.MapFrom(s => s.Name))
                .ForMember(d => d.Surname, source => source.MapFrom(s => s.Surname))
                .ForMember(d => d.UserName, source => source.MapFrom(s => s.UserName));

            CreateMap<User, UserProfileDTO>()
                .ForMember(d => d.Name, source => source.MapFrom(s => s.Name))
                .ForMember(d => d.Surname, source => source.MapFrom(s => s.Surname))
                .ForMember(d => d.UserName, source => source.MapFrom(s => s.UserName))
                .ForMember(d => d.RoleName, source => source.MapFrom(s => s.RoleName));
        }
    }
}
