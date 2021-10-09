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
    public class ProductMap: Profile
    {
        public ProductMap()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(d => d.Name, source => source.MapFrom(s => s.Name))
                .ForMember(d => d.ProductCode, source => source.MapFrom(s => s.ProductCode))
                .ForMember(d => d.Countable, source => source.MapFrom(s => s.Countable))
                .ForMember(d => d.MeasureUnit, source => source.MapFrom(s => s.MeasureUnit))
                .ForMember(d => d.IsStockMenagment, source => source.MapFrom(s => s.IsStockMenagment))
                .ForMember(d => d.SellUnit, source => source.MapFrom(s => s.SellUnit));

            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.Name, source => source.MapFrom(s => s.Name))
                .ForMember(d => d.ProductCode, source => source.MapFrom(s => s.ProductCode))
                .ForMember(d => d.Countable, source => source.MapFrom(s => s.Countable))
                .ForMember(d => d.MeasureUnit, source => source.MapFrom(s => s.MeasureUnit))
                .ForMember(d => d.IsStockMenagment, source => source.MapFrom(s => s.IsStockMenagment))
                .ForMember(d => d.SellUnit, source => source.MapFrom(s => s.SellUnit));
        }
    }
}
