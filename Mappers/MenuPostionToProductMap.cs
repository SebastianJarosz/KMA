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
    public class MenuPostionToProductMap : Profile
    {
        public MenuPostionToProductMap()
        {
            CreateMap<MenuPostionDTO, MenuPostionToProduct>()
                .ForMember(d => d.MenuPostionCode, source => source.MapFrom(s => s.MenuPostionCode));

            CreateMap<MenuPostionDTO.ProductsList, MenuPostionToProduct>()
                .ForMember(d => d.ProductCode, source => source.MapFrom(s => s.ProductCode))
                .ForMember(d => d.QuantityOfProduct, source => source.MapFrom(s => s.QuantityOfProduct));

            CreateMap<Igridient, MenuPostionDTO.ProductsList> ()
                .ForMember(d => d.ProductCode, source => source.MapFrom(s => s.ProductCode))
                .ForMember(d => d.ProductName, source => source.MapFrom(s => s.ProductName))
                .ForMember(d => d.QuantityOfProduct, source => source.MapFrom(s => s.QuantityOfProduct));
            CreateMap<MenuPostionDTO.ProductsList, Igridient>()
                .ForMember(d => d.ProductCode, source => source.MapFrom(s => s.ProductCode))
                .ForMember(d => d.ProductName, source => source.MapFrom(s => s.ProductName))
                .ForMember(d => d.QuantityOfProduct, source => source.MapFrom(s => s.QuantityOfProduct));
        }
    }
}
