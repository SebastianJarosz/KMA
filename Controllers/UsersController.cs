using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Appsettings;
using KMA.DTOS.UsersDTO;
using KMA.Models;
using KMA.Repository.Classes;
using KMA.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KMA.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User, string> _userRepository;
        private readonly IRepository<Role, string> _roleRepository;
        private readonly AuthApplicationSettings _appSettings;

        public UsersController(IMapper mapper, IRepository<User, string> userRepository,
           IRepository<Role, string> roleRepository, IOptions<AuthApplicationSettings> appSettings)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _appSettings = appSettings.Value;
    }

        // GET: api/<UsersController>/v1/ListOfUser
        [HttpGet("ListOfUser")]
        [Authorize]
        public async Task<Object> GetUserAllProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userRepository.GetAsync(userId);
            var adminRole = await _roleRepository.FindAsync(_appSettings.AdminRole);

            if (user.RoleName == adminRole.Id)
            {
                try
                {
                    var userList = await _userRepository.GetAllAsync();
                    var userDTOList = userList.Select(user => _mapper.Map<UserProfileDTO>(user)).OrderBy(user => user.Name).ToList();
                    return userDTOList;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(403);
        }

        // GET: api/<UsersController>/v1/UserProfile/{userName}
        [HttpGet("UserProfile/{userName}")]
        [Authorize]
        public async Task<Object> UserProfile(string userName)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userRepository.GetAsync(userId);
            var adminRole = await _roleRepository.FindAsync(_appSettings.AdminRole);

            if (user.RoleName == adminRole.Id)
            {
                try
                {
                    return _mapper.Map<UserProfileDTO>(await _userRepository.GetAsync(userName));
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(403);
        }

        // GET: api/<UsersController>/v1/MyProfile
        [HttpGet("MyProfile")]
        [Authorize]
        public async Task<Object> MyUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userRepository.GetAsync(userId);
            if (user != null)
            {
                try
                {
                    return _mapper.Map<UserProfileDTO>(user); ;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(403);
        }

        // PUT api/<UsersController>/v1/EditUSer
        [HttpPut("EditUser")]
        public async Task<Object> EditUser()
        {
            try
            {

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return StatusCode(403);
        }

        // POST api/<UsersController>/v1/AddUser
        [HttpPost]
        [Route("AddUser")]
        public async Task<Object> AddUser(UserDTO model)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userRepository.GetAsync(userId);
            var adminRole = await _roleRepository.FindAsync(_appSettings.AdminRole);

            if (user.RoleName == adminRole.Id)
            {
                try
                {
                    var newUser = _mapper.Map<User>(model);
                    newUser.Role = await _roleRepository.FindAsync(_appSettings.NormalUserRole);
                    var result = await _userRepository.AddAsync(newUser, model.Password);
                    return StatusCode(204);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(403);
        }

        // POST api/<UsersController>/v1/UserLogin
        [HttpPost]
        [Route("UserLogin")]
        public async Task<Object> LoginUser(Login model)
        {
            var user = await _userRepository.FindAsync(model.UserName, model.Password);
            if (user != null && user.Status == 0)
            {
                try
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                            new Claim("UserID", user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(1440),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);

                    var userProfile = _mapper.Map<UserProfileDTO>(user);
                    var role = await _roleRepository.GetAsync(userProfile.RoleName);
                    userProfile.RoleName = role.Name.ToLower();
                    userProfile.Token = token;
                    return Ok(userProfile);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(403);
        }

        //PUT api/<UsersController>/v1/DeleteByAdmin/{userName}
        [HttpDelete("DeleteByAdmin/{userName}")]
        [Authorize] 
        public async Task<Object> DeleteUser(string userName)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userRepository.GetAsync(userId);
            var adminRole = await _roleRepository.FindAsync(_appSettings.AdminRole);

            if (user.RoleName == adminRole.Id)
            {
                try
                {
                    var userToDelete = await _userRepository.GetAsync(userName);
                    await _userRepository.DeleteAsync(userToDelete);
                    return StatusCode(204);
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            return StatusCode(403);
        }
    }
}
