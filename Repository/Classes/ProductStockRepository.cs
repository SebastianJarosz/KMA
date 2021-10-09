using AutoMapper;
using KMA.Database;
using KMA.Models;

using KMA.Models.ProductManager;
using KMA.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KMA.Repository.Classes
{
    public class ProductStockRepository : IRepository<Product,string>
    {
        private readonly IMapper _mapper;
        protected readonly KMADbContext _context;
        public ProductStockRepository(IMapper mapper, KMADbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<ICollection<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> FindAllAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<Product> AddAsync(Product newModel, params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product updated, params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Product t)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}