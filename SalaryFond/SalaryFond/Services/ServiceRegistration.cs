using Microsoft.Extensions.DependencyInjection;
using SalaryFond.ViewModels;
using SalaryFond.Services;

namespace SalaryFond.Services
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<AddCompanyViewModel>();

            services.AddSingleton<CompaniesRepository>();
            services.AddSingleton<WorkersRepository>();
            services.AddSingleton<WorkersManager>();
            return services;
        }
    }
}
