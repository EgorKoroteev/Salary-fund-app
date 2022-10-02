using SalaryFond.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryFond.Services;
using SalaryFond.Models;

namespace SalaryFond.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public AddCompanyViewModel AddCompany { get; }

        private WorkersManager _WorkersManager;

        private string _title = "Главное окно";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public IEnumerable<Company> Companies => _WorkersManager.Companies;
        public IEnumerable<Worker> Workers => _WorkersManager.Workers;

        public MainWindowViewModel(WorkersManager WorkersManager)
        {
           _WorkersManager = WorkersManager;
        }
    }
}
