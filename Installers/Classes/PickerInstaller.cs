using KMA.DTOS.OrderManagerDTO;
using KMA.DTOS.ProductManager;
using KMA.Installers.Interfaces;
using KMA.Models;
using KMA.Models.ProductManager;
using KMA.Pickers.Classes;
using KMA.Pickers.Interfaces;
using KMA.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMA.Installers.Classes
{
    public class PickerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IPicker<Igridient,string>, ProductPicker>();
            services.AddScoped<IPicker<OrderPostion, string>, MenuPostionPicker>();
        }
    }
}
