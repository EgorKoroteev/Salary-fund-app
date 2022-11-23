using SalaryFond.ViewModels.Base;
namespace SalaryFond.ViewModels
{
    internal class AddCompanyViewModel : ViewModelBase
    {
        public MainWindowViewModel MainModel { get; internal set; }
        private string _title = "Добавление нового подразделения";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        
    }
}
