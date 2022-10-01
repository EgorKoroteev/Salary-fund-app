using SalaryFond.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public AddCompanyViewModel AddCompany { get; }

        private string _title = "Главное окно";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public MainWindowViewModel(AddCompanyViewModel NewCompany)
        {
            AddCompany = NewCompany;
            NewCompany.MainModel = this;
        }
    }
}
