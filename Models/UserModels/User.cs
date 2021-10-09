
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Models
{
    public class User: IdentityUser
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Surname { get; set; }
        public string RoleName { get; set; }
        [ForeignKey("RoleName")]
        public Role Role { get; set; }
        public int Status { get; set; }
    }
}
