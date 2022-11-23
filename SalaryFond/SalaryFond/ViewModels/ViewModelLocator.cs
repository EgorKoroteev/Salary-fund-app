using Microsoft.Extensions.DependencyInjection;

namespace SalaryFond.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();


    }
}
