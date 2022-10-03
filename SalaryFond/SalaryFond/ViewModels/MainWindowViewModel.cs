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
            var worker = (Worker)p;

            var dlg = new WorkerEditorWindow
            {
                FIO = worker.FIO
            };

            if (dlg.ShowDialog() == true)
            {
                MessageBox.Show("Пользователь выполнил редактирование");
            }
            else
            {
                MessageBox.Show("Пользователь отказался");
            }
        }

        #endregion

        #endregion

        public IEnumerable<Company> Companies => _WorkersManager.Companies;
        public IEnumerable<Worker> Workers => _WorkersManager.Workers;

        public MainWindowViewModel(WorkersManager WorkersManager) => _WorkersManager = WorkersManager;
    }
}
