using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.DTOS.UsersDTO
{
    public class UserProfileDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
    }
}
