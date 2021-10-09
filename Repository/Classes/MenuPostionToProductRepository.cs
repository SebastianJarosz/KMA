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
    public class MenuPostionToProductRepository : IRepository<MenuPostionToProduct, string>
    {
        private readonly IMapper _mapper;
        protected readonly KMADbContext _context;
        public MenuPostionToProductRepository(IMapper mapper, KMADbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<MenuPostionToProduct>> GetAllAsync()
        {
            return await _context.MenuPostionToProduct.ToListAsync();
        }

        public Task<MenuPostionToProduct> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<MenuPostionToProduct> FindAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<MenuPostionToProduct>> FindAllAsync(params string[] key)
        {
            return await _context.MenuPostionToProduct
                        .Where(p => p.MenuPostionCode == key[0])
                        .ToListAsync();
        }

        public async Task<MenuPostionToProduct> AddAsync(MenuPostionToProduct newModel, params string[] key)
        {
            _context.MenuPostionToProduct.Add(newModel);
            await _context.SaveChangesAsync();
            return newModel;
        }

        public Task<MenuPostionToProduct> UpdateAsync(MenuPostionToProduct updated, params string[] key)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(MenuPostionToProduct t)
        {
            _context.MenuPostionToProduct.Remove(t);
            return await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}