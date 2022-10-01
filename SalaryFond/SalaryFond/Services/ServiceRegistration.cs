using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SalaryFond.ViewModels;

namespace SalaryFond.Services
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            return services;
        }
    }
}
