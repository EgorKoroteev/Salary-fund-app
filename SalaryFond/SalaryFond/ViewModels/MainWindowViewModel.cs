using SalaryFond.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryFond.Services;
using SalaryFond.Models;
using System.Windows.Input;
using SalaryFond.Infrastructure.Commads;
using SalaryFond.Views.Windows;
using System.Windows;
using SalaryFond.Services.Interfaces;

namespace SalaryFond.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public AddCompanyViewModel AddCompany { get; }

        private WorkersManager _WorkersManager;
        private IUserDialogService _UserDialog;
        private string _title = "Главное окно";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #region Выбранное подразделение

        private Company _SelectedCompany;

        public Company SelectedCompany { get => _SelectedCompany; set => Set(ref _SelectedCompany, value); }
        #endregion

        #region Выбранный сотрудник

        private Worker _SelectedWorker;

        public Worker SelectedWorker { get => _SelectedWorker; set => Set(ref _SelectedWorker, value); }
        #endregion

        #region Команды

        #region Команда редактирования сотрудника

        private ICommand _EditWorkerCommand;

        public ICommand EditWorkerCommand => _EditWorkerCommand ??= new LambdaCommand(OnEditWorkerCommandExecuted, CanEditWorkerCommandExecute);

        private static bool CanEditWorkerCommandExecute(object p) => p is Worker;

        private void OnEditWorkerCommandExecuted(object p)
        {
            if (_UserDialog.Edit(p))
            {
                _WorkersManager.Update((Worker)p);

                _UserDialog.ShowInformation("Сотрудник отредактирован", "Медеджер сотрудников");
            }
            else
            {
                _UserDialog.ShowWarning("Отказ от редактирования", "Медеджер сотрудников");
            }

        }

        #endregion

        #region Команда создания нового сотрудника

        private ICommand _CreateNewWorkerCommand;

        public ICommand CreateNewWorkerCommand => _CreateNewWorkerCommand ??= new LambdaCommand(OnCreateNewWorkerCommandExecuted, CanCreateNewWorkerCommandExecute);

        private static bool CanCreateNewWorkerCommandExecute(object p) => p is Company;

        private void OnCreateNewWorkerCommandExecuted(object p)
        {
            var company = (Company)p;

            var worker = new Worker();

            if (!_UserDialog.Edit(worker) || _WorkersManager.Create(worker, company.Name))
            {
                OnPropertyChanged(nameof(Workers));
                return;
            }

            if (_UserDialog.Confirm("Не удалось добавить нового сотрудника. Повторить?", "Менеджер сотрудников"))
            {
                OnCreateNewWorkerCommandExecuted(p);
            }

        }

        #endregion

        #endregion

        public IEnumerable<Company> Companies => _WorkersManager.Companies;
        public IEnumerable<Worker> Workers => _WorkersManager.Workers;

        public MainWindowViewModel(WorkersManager WorkersManager, IUserDialogService UserDialog)
        {
            _WorkersManager = WorkersManager;
            _UserDialog = UserDialog;
        }
    }
}
