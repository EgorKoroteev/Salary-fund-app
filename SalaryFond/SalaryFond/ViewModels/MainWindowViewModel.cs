﻿using SalaryFond.ViewModels.Base;
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
using SalaryFond.Services.WorkWithFiles;
using System.Collections.ObjectModel;

namespace SalaryFond.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private WorkersManager _WorkersManager;
        private IUserDialogService _UserDialog;
        private WorkFiles _WorkFiles;

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

        #region Выбранный месяц

        private Month _SelectedMonth;

        public Month SelectedMonth { get => _SelectedMonth; set => Set(ref _SelectedMonth, value); }
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
                var selectCompany = SelectedCompany;
                SelectedCompany = null;
                SelectedCompany = selectCompany;
                _WorkersManager.UpdateInformation();
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
        #region Команда удаления сотрудника

        private ICommand _RemoveWorkerCommand;

        public ICommand RemoveWorkerCommand => _RemoveWorkerCommand ??= new LambdaCommand(OnRemoveWorkerCommandExecuted, CanRemoveWorkerCommandExecute);

        private bool CanRemoveWorkerCommandExecute(object p) => p is Worker worker && SelectedCompany != null && SelectedCompany.Workers.Contains(worker);

        private void OnRemoveWorkerCommandExecuted(object p)
        {
            SelectedCompany.Workers.Remove((Worker)p);
            var selectedCompany = SelectedCompany;
            SelectedCompany = null;
            SelectedCompany = selectedCompany;
        }

        #endregion

        #region Команда создания дополнительной должности

        private ICommand _CreateAdditionalProfessionCommand;

        public ICommand CreateAdditionalProfessionCommand => _CreateAdditionalProfessionCommand ??= new LambdaCommand(OnCreateAdditionalProfessionCommandExecuted, CanCreateAdditionalProfessionCommandExecute);

        private static bool CanCreateAdditionalProfessionCommandExecute(object p) => p is Worker;

        private void OnCreateAdditionalProfessionCommandExecuted(object p)
        {
            var worker = (Worker)p;
            var additional = new AdditionalProfession();

            if (!_UserDialog.Edit(additional) || _WorkersManager.CreateAdditionalProfession(additional, worker.FIO))
            {
                var selectCompany = SelectedCompany;
                SelectedCompany = null;
                SelectedCompany = selectCompany;
                OnPropertyChanged(nameof(Workers));
                return;
            }

            if (_UserDialog.Confirm("Не удалось добавить новую должность. Повторить?", "Менеджер сотрудников"))
            {
                OnCreateAdditionalProfessionCommandExecuted(p);
            }

        }

        #endregion

        #region Команда создания штрафа

        private ICommand _CreatePenaltieCommand;

        public ICommand CreatePenaltieCommand => _CreatePenaltieCommand ??= new LambdaCommand(OnCreatePenaltieCommandExecuted, CanCreatePenaltieCommandExecute);

        private static bool CanCreatePenaltieCommandExecute(object p) => p is Worker;

        private void OnCreatePenaltieCommandExecuted(object p)
        {
            var worker = (Worker)p;
            var penaltie = new Penalties();

            if (!_UserDialog.Edit(penaltie) || _WorkersManager.CreatePenaltie(penaltie, worker.FIO))
            {
                var selectCompany = SelectedCompany;
                SelectedCompany = null;
                SelectedCompany = selectCompany;
                OnPropertyChanged(nameof(Workers));
                return;
            }

            if (_UserDialog.Confirm("Не удалось добавить новую должность. Повторить?", "Менеджер сотрудников"))
            {
                OnCreateAdditionalProfessionCommandExecuted(p);
            }

        }

        #endregion

        #region Команда редактирования подразделения

        private ICommand _EditCompanyCommand;

        public ICommand EditCompanyCommand => _EditCompanyCommand ??= new LambdaCommand(OnEditCompanyCommandExecuted, CanEditCompanyCommandExecute);

        private static bool CanEditCompanyCommandExecute(object p) => p is Company;

        private void OnEditCompanyCommandExecuted(object p)
        {
            if (_UserDialog.Edit(p))
            {
                _WorkersManager.UpdateCompany((Company)p);

                var selectedMonth = SelectedMonth;
                SelectedMonth = null;
                SelectedMonth = selectedMonth;
                _UserDialog.ShowInformation("Подразделение отредактировано", "Медеджер подразделений");
            }
            else
            {
                _UserDialog.ShowWarning("Отказ от редактирования", "Медеджер подразделений");
            }

        }

        #endregion
        #region Команда создания нового подразделения

        private ICommand _CreateNewCompanyCommand;

        public ICommand CreateNewCompanyCommand => _CreateNewCompanyCommand ??= new LambdaCommand(OnCreateNewCompanyCommandExecuted, CanCreateNewCompanyCommandExecute);

        private static bool CanCreateNewCompanyCommandExecute(object p) => p is Month;

        private void OnCreateNewCompanyCommandExecuted(object p)
        {
            var month = (Month)p;

            var company = new Company();

            if (!_UserDialog.Edit(company) || _WorkersManager.CreateCompany(company, month.Name))
            {
                OnPropertyChanged(nameof(Companies));
                return;
            }

            if (_UserDialog.Confirm("Не удалось добавить нового сотрудника. Повторить?", "Менеджер сотрудников"))
            {
                OnCreateNewWorkerCommandExecuted(p);
            }

        }

        #endregion
        #region Команда удаления подразделения

        private ICommand _RemoveCompanyCommand;

        public ICommand RemoveCompanyCommand => _RemoveCompanyCommand ??= new LambdaCommand(OnRemoveCompanyCommandExecuted, CanRemoveCompanyCommandExecute);

        private bool CanRemoveCompanyCommandExecute(object p) => p is Company company && SelectedMonth != null && SelectedMonth.Companies.Contains(company);

        private void OnRemoveCompanyCommandExecuted(object p)
        {
            SelectedMonth.Companies.Remove((Company)p);
            var selectedMonth = SelectedMonth;
            SelectedMonth = null;
            SelectedMonth = selectedMonth;
        }

        #endregion


        #region Команда для выгрузги БД

        private ICommand _ExportBDCommand;

        public ICommand ExportBDCommand => _ExportBDCommand ??= new LambdaCommand(OnExportBDCommandExecuted, CanExportBDCommandExecute);

        private static bool CanExportBDCommandExecute(object p) => true;

        private void OnExportBDCommandExecuted(object p)
        {
            _WorkFiles.WriteJsonBD(_WorkersManager.Months);
        }

        #endregion
        #region Команда для загрузки БД

        private ICommand _ImportBDCommand;

        public ICommand ImportBDCommand => _ImportBDCommand ??= new LambdaCommand(OnImportBDCommandExecuted, CanImportBDCommandExecute);

        private static bool CanImportBDCommandExecute(object p) => true;

        private void OnImportBDCommandExecuted(object p)
        {
            var months = _WorkFiles.ReadJsonBD();
            _WorkersManager.SetCompaniesFromBD(months);
        }

        #endregion

        #region Команда для выгрузги Excel

        private ICommand _ExportExcelCommand;

        public ICommand ExportExcelCommand => _ExportExcelCommand ??= new LambdaCommand(OnExportExcelCommandExecuted, CanExportExcelCommandExecute);

        private static bool CanExportExcelCommandExecute(object p) => true;

        private void OnExportExcelCommandExecuted(object p)
        {
            _WorkFiles.WriteExcel(_WorkersManager.Companies);
        }

        #endregion

        #region Команда для обновления всей информации

        private ICommand _UpdateCommand;

        public ICommand UpdateCommand => _UpdateCommand ??= new LambdaCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);

        private static bool CanUpdateCommandExecute(object p) => true;

        private void OnUpdateCommandExecuted(object p)
        {
            // Пересчет всех методов связанных с зарплатой
        }

        #endregion

        #endregion

        public ObservableCollection<Company> Companies => _WorkersManager.Companies;

        public ObservableCollection<Worker> Workers => _WorkersManager.Workers;

        public ObservableCollection<Month> Months => _WorkersManager.Months;


        public MainWindowViewModel(WorkersManager WorkersManager, IUserDialogService UserDialog, WorkFiles WorkFiles)
        {
            _WorkersManager = WorkersManager;
            _UserDialog = UserDialog;
            _WorkFiles = WorkFiles;
        }
    }
}
