using KMA.Installers.Interfaces;
using KMA.Models;
using KMA.Repository.Classes;
using KMA.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Installers.Classes
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IRepository<User,string>, UserRepository>();
            services.AddScoped<IRepository<Role,string>, RoleRepository>();
        }
    }
}
