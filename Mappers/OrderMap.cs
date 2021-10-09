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
    public class OrderMap : Profile
    {
        public OrderMap()
        {
            CreateMap<OrderDTO, Order>()
                .ForMember(d => d.OrderGuid, source => source.MapFrom(s => s.OrderGuid))
                .ForMember(d => d.OrderNumber, source => source.MapFrom(s => s.OrderNumber))
                .ForMember(d => d.CreationTime, source => source.MapFrom(s => s.CreationTime))
                .ForMember(d => d.ModificationTime, source => source.MapFrom(s => s.ModificationTime))
                .ForMember(d => d.Status, source => source.MapFrom(s => s.Status));

            CreateMap<Order, OrderDTO>()
                .ForMember(d => d.OrderGuid, source => source.MapFrom(s => s.OrderGuid))
                .ForMember(d => d.OrderNumber, source => source.MapFrom(s => s.OrderNumber))
                .ForMember(d => d.CreationTime, source => source.MapFrom(s => s.CreationTime))
                .ForMember(d => d.ModificationTime, source => source.MapFrom(s => s.ModificationTime))
                .ForMember(d => d.Status, source => source.MapFrom(s => s.Status));
        }
    }
}
