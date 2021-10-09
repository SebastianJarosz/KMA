using KMA.Installers.Interfaces;
using KMA.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Installers.Classes
{
    public class MapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration Configuration)
        {
            services.AddAutoMapper(c => c.AddProfile<UserMap>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<ProductMap>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<MenuPostionMap>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<MenuPostionToProductMap>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<OrderMap>(), typeof(Startup));
        }
    }
}
