using AutoMapper;
using KMA.DTOS.OrderManagerDTO;
using KMA.DTOS.ProductManager;
using KMA.DTOS.UsersDTO;
using KMA.Models;
using KMA.Models.OrderManager;
using KMA.Models.ProductManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Mappers
{
    public class OrderToMenuPostionMap : Profile
    {
        public OrderToMenuPostionMap()
        {
            CreateMap<OrderDTO, OrderToMenuPostion>()
                .ForMember(d => d.OrderGuid, source => source.MapFrom(s => s.OrderGuid));

            CreateMap<OrderPostion, OrderToMenuPostion>()
                .ForMember(d => d.MenuPostionCode, source => source.MapFrom(s => s.MenuPostionCode))
                .ForMember(d => d.QuantityOfMenuPostion, source => source.MapFrom(s => s.QuantityOfMenuPostion));
        }
    }
}
