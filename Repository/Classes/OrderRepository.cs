using AutoMapper;
using KMA.Database;
using KMA.Models.OrderManager;
using KMA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Repository.Classes
{
    public class OrderRepository : IRepository<Order, string>
    {
        private readonly IMapper _mapper;
        protected readonly KMADbContext _context;
        public OrderRepository(IMapper mapper, KMADbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Order> AddAsync(Order newModel, params string[] key)
        {
            var lastOrderNumber = _context.Order.Where(x => x.CreationTime == _context.Order.Max(x => x.CreationTime))
                                                .Select(x => x.OrderNumber).FirstOrDefault();
            if(lastOrderNumber >= 99)
            {
                lastOrderNumber = 0;
            }
            
            newModel.OrderNumber = lastOrderNumber + 1;
            newModel.OrderGuid = Guid.NewGuid().ToString();
            newModel.CreationTime = DateTime.Now;
            newModel.ModificationTime = DateTime.Now;
            newModel.Status = Status.InProgress;
            _context.Order.Add(newModel);
            await _context.SaveChangesAsync();
            return newModel;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Order t)
        {
            _context.Order.Remove(t);
            return await _context.SaveChangesAsync();
        }

        public Task<ICollection<Order>> FindAllAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<Order> FindAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task<Order> GetAsync(string key)
        {
            return await _context.Order.FindAsync(key);
        }

        public async Task<Order> UpdateAsync(Order updated, params string[] key)
        {
            if (updated == null)
                return null;

            var existing = await _context.Order.Where(x => x.OrderGuid == key[0]).FirstOrDefaultAsync();
            if (existing != null)
            {
                updated.OrderGuid = existing.OrderGuid;
                _context.Entry(existing).CurrentValues.SetValues(updated);
                await _context.SaveChangesAsync();
            }
            return existing;
        }
    }
}
