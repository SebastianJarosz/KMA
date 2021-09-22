using KMA.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Models
{
    public class Role:IdentityRole, IEntity
    {
        public string Description { get; set; }
    }
}
