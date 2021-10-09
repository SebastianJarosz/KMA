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
    public class MenuPostionRepository : IRepository<MenuPostion,string>
    {
        private readonly IMapper _mapper;
        protected readonly KMADbContext _context;
        public MenuPostionRepository(IMapper mapper, KMADbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<MenuPostion>> GetAllAsync()
        {
            return await _context.MenuPostion.ToListAsync();
        }

        public async Task<MenuPostion> GetAsync(string key)
        {
            return await _context.MenuPostion.FindAsync(key);
        }

        public async Task<MenuPostion> FindAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MenuPostion>> FindAllAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public async Task<MenuPostion> AddAsync(MenuPostion newModel, params string[] key)
        {
            _context.MenuPostion.Add(newModel);
            await _context.SaveChangesAsync();
            return newModel;
        }

        public async Task<MenuPostion> UpdateAsync(MenuPostion updated, params string[] key)
        {
            if (updated == null)
                return null;

            var existing = await _context.MenuPostion.Where(x => x.MenuPostionCode == key[0]).FirstOrDefaultAsync();
            if (existing != null)
            {
                updated.MenuPostionCode = existing.MenuPostionCode;
                _context.Entry(existing).CurrentValues.SetValues(updated);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public async Task<int> DeleteAsync(MenuPostion t)
        {
            _context.MenuPostion.Remove(t);
            return await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}