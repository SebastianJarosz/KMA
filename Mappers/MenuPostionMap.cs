using AutoMapper;
using KMA.DTOS.ProductManager;
using KMA.DTOS.UsersDTO;
using KMA.Models;
using KMA.Models.ProductManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Mappers
{
    public class MenuPostionMap : Profile
    {
        public MenuPostionMap()
        {
            CreateMap<MenuPostionDTO, MenuPostion>()
                .ForMember(d => d.Name, source => source.MapFrom(s => s.Name))
                .ForMember(d => d.MenuPostionCode, source => source.MapFrom(s => s.MenuPostionCode))
                .ForMember(d => d.PLU, source => source.MapFrom(s => s.PLU))
                .ForMember(d => d.UnitPrice, source => source.MapFrom(s => s.UnitPrice));

            CreateMap<MenuPostion, MenuPostionDTO>()
                .ForMember(d => d.Name, source => source.MapFrom(s => s.Name))
                .ForMember(d => d.MenuPostionCode, source => source.MapFrom(s => s.MenuPostionCode))
                .ForMember(d => d.PLU, source => source.MapFrom(s => s.PLU))
                .ForMember(d => d.UnitPrice, source => source.MapFrom(s => s.UnitPrice));
        }
    }
}
