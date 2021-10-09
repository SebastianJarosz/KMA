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
    public class ProductRepository : IRepository<Product,string>
    {
        private readonly IMapper _mapper;
        protected readonly KMADbContext _context;
        public ProductRepository(IMapper mapper, KMADbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetAsync(string key)
        {
            return await _context.Product.FindAsync(key);
        }

        public async Task<Product> FindAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Product>> FindAllAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> AddAsync(Product newModel, params string[] key)
        {
            _context.Product.Add(newModel);
            await _context.SaveChangesAsync();
            return newModel;
        }

        public async Task<Product> UpdateAsync(Product updated, params string[] key)
        {
            if (updated == null)
                return null;

            Product existing = await _context.Product.FindAsync(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public async Task<int> DeleteAsync(Product t)
        {
            _context.Product.Remove(t);
            return await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}