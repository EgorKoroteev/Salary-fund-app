using SalaryFond.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
