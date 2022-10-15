using SalaryFond.Models;
using SalaryFond.Services;
using SalaryFond.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.ViewModels
{
    class ResultCompaniesViewModel : ViewModelBase
    {
        private WorkersManager _WorkersManager;

        public ObservableCollection<Company> Companies => _WorkersManager.Companies;

        public ResultCompaniesViewModel(WorkersManager WorkersManager)
        {
            _WorkersManager = WorkersManager;
        }
    }
}
