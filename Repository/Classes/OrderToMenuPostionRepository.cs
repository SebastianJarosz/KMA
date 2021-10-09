using AutoMapper;
using KMA.Database;
using KMA.Models;
using KMA.Models.OrderManager;
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
    public class OrderToMenuPostionRepository : IRepository<OrderToMenuPostion, string>
    {
        private readonly IMapper _mapper;
        protected readonly KMADbContext _context;
        public OrderToMenuPostionRepository(IMapper mapper, KMADbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<OrderToMenuPostion>> GetAllAsync()
        {
            return await _context.OrderToMenuPostion.ToListAsync();
        }

        public Task<OrderToMenuPostion> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<OrderToMenuPostion> FindAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<OrderToMenuPostion>> FindAllAsync(params string[] key)
        {
            return await _context.OrderToMenuPostion
            .Where(p => p.OrderGuid == key[0])
            .ToListAsync();
        }

        public async Task<OrderToMenuPostion> AddAsync(OrderToMenuPostion newModel, params string[] key)
        {
            _context.OrderToMenuPostion.Add(newModel);
            await _context.SaveChangesAsync();
            return newModel;
        }

        public Task<OrderToMenuPostion> UpdateAsync(OrderToMenuPostion updated, params string[] key)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(OrderToMenuPostion t)
        {
            _context.OrderToMenuPostion.Remove(t);
            return await _context.SaveChangesAsync();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}