using Microsoft.Extensions.DependencyInjection;
using SalaryFond.ViewModels;
using SalaryFond.Services;
using SalaryFond.Services.Interfaces;
using SalaryFond.Services.WorkWithFiles;

namespace SalaryFond.Services
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<AddCompanyViewModel>();
            services.AddSingleton<ResultCompaniesViewModel>();

            services.AddSingleton<CompaniesRepository>();
            services.AddSingleton<WorkersRepository>();
            services.AddSingleton<WorkersManager>();
            services.AddSingleton<WorkFiles>();

            services.AddTransient<IUserDialogService, WindowsUserDialogService>();
            return services;
        }
    }
}
