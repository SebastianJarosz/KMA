using AutoMapper;
using KMA.Database;
using KMA.Models;
using KMA.Models.Interfaces;
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
    public class RoleRepository : IRepository<Role,string>
    {
        private readonly IMapper _mapper;
        protected readonly KMADbContext _context;
        private RoleManager<Role> _roleManager;
        public RoleRepository(IMapper mapper, KMADbContext context, 
            RoleManager<Role> roleManager)
        {
            _mapper = mapper;
            _context = context;
            _roleManager = roleManager;
        }

        public Task<ICollection<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetAsync(string key)
        {
            return await _roleManager.FindByIdAsync(key);
        }

        public async Task<Role> FindAsync(params string[] key)
        {
            return await _roleManager.FindByNameAsync(key[0]);
        }

        public Task<Role> FindAllAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<Role> AddAsync(Role newModel, params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateAsync(Role updated, params string[] key)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Role t)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }
}