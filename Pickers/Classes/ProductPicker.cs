using AutoMapper;
using KMA.Database;
using KMA.DTOS.ProductManager;
using KMA.Models.ProductManager;
using KMA.Pickers.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Pickers.Classes
{
    public class ProductPicker : IPicker<Igridient, string>
    {
        private readonly IMapper _mapper;
        protected readonly KMADbContext _context;
        public ProductPicker(IMapper mapper, KMADbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<Igridient>> AsyncGetAllItems(string key)
        {
            var productList = await (from m in _context.MenuPostionToProduct
                              from p in _context.Product
                              where m.MenuPostionCode == key && m.ProductCode == p.ProductCode
                              select new
                              {
                                  name = p.Name,
                                  code = p.ProductCode,
                                  quantity = m.QuantityOfProduct
                              }).ToListAsync();
            var igridientList = productList.Select(product => new Igridient()
            {
                ProductName = product.name,
                ProductCode = product.code,
                QuantityOfProduct = product.quantity
            }).ToList();
            return igridientList;
        }

        public Task<Igridient> AsyncGetItem(string key)
        {
            throw new NotImplementedException();
        }
    }
}















































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































