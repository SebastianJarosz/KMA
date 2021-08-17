/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KMA.DTOS.UsersDTO;
using KMA.Models;
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
        private IRepository<User> _userRepository;
        public UsersController(IMapper mapper, IRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        // GET: api/<UsersController>/v1/ListOfUser
        [HttpGet("ListOfUser")]
        [Authorize]
        public async Task<Object> GetUserProfile()
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

        // GET: api/<UsersController>/v1/UserProfile/{userGuid}
        [HttpGet("UserProfile/{userGuid}")]
        [Authorize]
        public async Task<Object> UserProfile(string userGuid)
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

        // GET: api/<UsersController>/v1/MyProfile
        [HttpGet("MyProfile")]
        [Authorize]
        public async Task<Object> MyUserProfile()
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

        // GET api/<UsersController>/v1/CheckEmail/{email}
        [HttpGet]
        [Route("CheckEmail/{email}")]
        public async Task<Object> CheckEmail(string email)
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

        // GET api/<UsersController>/v1/CheckUserName/{userName}
        [HttpGet]
        [Route("CheckUserName/{userName}")]
        public async Task<Object> CheckUserName(string userName)
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

        // PUT api/<UsersController>/v1/ChangeUserRole
        [HttpPut("ChangeUserRole")]
        public async Task<Object> ChangeUserRole(UserRoleChanger model)
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

        // POST api/<UsersController>/v1/Registry
        [HttpPost]
        [Route("v1/Registry")]
        public async Task<Object> PostUser(UserDTO model)
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

        // POST api/<UsersController>/v1/UserLogin
        [HttpPost]
        [Route("v1/UserLogin")]
        public async Task<Object> LoginUser(Login model)
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

        // PUT api/<UsersController>/v1/Delete
        [HttpPut("Delete")]
        [Authorize]
        public async Task<Object> UserDeleteOwnAccount()
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

        //PUT api/<UsersController>/v1/DeleteByAdmin/{userGuid}
        [HttpDelete("DeleteByAdmin/{userGuid}")]
        [Authorize]
        public async Task<Object> DeleteUser(string userGuid)
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
    }
}
*/