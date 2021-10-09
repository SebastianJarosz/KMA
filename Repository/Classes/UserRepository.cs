using AutoMapper;
using KMA.Database;
using KMA.Models;
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
    public class UserRepository : IRepository<User, string>
    {
        protected readonly KMADbContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public UserRepository(KMADbContext context, 
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<User> AddAsync(User newModel, params string[] key)
        {
            newModel.RoleName = newModel.Role.Name;
            await _userManager.CreateAsync(newModel, key[0]);
            await _userManager.AddToRoleAsync(newModel, newModel.RoleName);
            return newModel;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(User t)
        {
            try
            {
                t.Status = 1;
                await _userManager.UpdateAsync(t);
                return 0;
            }
            catch(Exception ex)
            {
                return 1;
            }
        }

        public Task<ICollection<User>> FindAllAsync(params string[] key)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindAsync(params string[] key)
        {
            if (await _userManager.FindByNameAsync(key[0]) != null)
            {
                var returnUser = await _userManager.FindByNameAsync(key[0]);
                if (await _userManager.CheckPasswordAsync(returnUser, key[1]))
                {
                    return returnUser;
                }
            }
            return null;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User> GetAsync(string key)
        {
            var user = await _userManager.FindByIdAsync(key);
            if (user != null)
            {
                return user;
            }
            else
            {
                return await _userManager.FindByNameAsync(key);
            }
        }

        public Task<User> UpdateAsync(User updated, params string[] key)
        {
            throw new NotImplementedException();
        }
    }
}
