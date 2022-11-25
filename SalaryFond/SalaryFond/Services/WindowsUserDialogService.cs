using Microsoft.Win32;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using SalaryFond.Models;
using SalaryFond.Services.Interfaces;
using SalaryFond.Views.Windows;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SalaryFond.Services
{
    internal class WindowsUserDialogService : IUserDialogService
    {
        public bool OpenFile(string Title, out string SelectedFile, string Filter = "Все файлы (*.*)|*.*")
        {
            var file_dialog = new OpenFileDialog()
            {
                Title = Title,
                Filter = Filter
            };

            if (file_dialog.ShowDialog() != true)
            {
                SelectedFile = null;
                return false;
            }

            SelectedFile = file_dialog.FileName;
            return true;
        }

        public void OpenWorkerList(ObservableCollection<Worker> workers)
        {
            var dlg = new ListWorkersWindow()
            {
                WorkerList = workers,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return;
        }

        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            switch (item)
            {
                case YearSalary year:
                    return EditYear(year);

                case Worker worker:
                    return EditWorker(worker);

                case Company company:
                    return EditCompany(company);

                case AdditionalProfession additionalProfession:
                    return EditAdditionalProfession(additionalProfession);

                case Penalties penaltie:
                    return EditPenaltie(penaltie);

                default: throw new NotSupportedException($"Редактирование объекта типа {item.GetType().Name} не поддерживается");
            }
        }

        public void ShowInformation(string Information, string Caption) => MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);

        public void ShowError(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public bool Confirm(string Message, string Caption, bool Exclamation = false) => 
            MessageBox.Show(Message, 
                Caption, 
                MessageBoxButton.YesNo, 
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question) == MessageBoxResult.Yes;

        private static bool EditYear(YearSalary year)
        {
            var dlg = new YearEditorWindow()
            {
                YearNumber = year.Name,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            year.Name = dlg.YearNumber;
            return true;
        }

        private static bool EditWorker(Worker worker)
        {
            var dlg = new WorkerEditorWindow
            {
                FIO = worker.FIO,
                MainProfession = worker.MainProfession,
                MainSalary = worker.MainSalary,
                WorkedHours = worker.WorkedHours,
                NormalHours = worker.NormalHours,
                PrizeBoss = worker.PrizeBoss,
                HolidayPay = worker.HolidayPay,
                SickPay = worker.SickPay,
                Prepayment = worker.Prepayment,
                RKO = worker.RKO,
                ExecutiveList = worker.ExecutiveList,
                TransferByCard = worker.TransferByCard,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            worker.FIO = dlg.FIO;
            worker.MainProfession = dlg.MainProfession;
            worker.MainSalary = dlg.MainSalary;
            worker.WorkedHours = dlg.WorkedHours;
            worker.NormalHours = dlg.NormalHours;
            worker.PrizeBoss = dlg.PrizeBoss;
            worker.HolidayPay = dlg.HolidayPay;
            worker.SickPay = dlg.SickPay;
            worker.Prepayment = dlg.Prepayment;
            worker.RKO = dlg.RKO;
            worker.ExecutiveList = dlg.ExecutiveList;
            worker.TransferByCard = dlg.TransferByCard;

            worker.SumResultSalary();
            worker.CalculateAdditionalAndPenaltie();

            return true;
        }

        private static bool EditCompany(Company company)
        {
            var dlg = new CompanyEditorWindow()
            {
                NameCompany = company.Name,
                Location = company.Location,
                PlanningSalaryFund = company.PlanningSalaryFund,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            company.Name = dlg.NameCompany;
            company.Location = dlg.Location;
            company.PlanningSalaryFund = dlg.PlanningSalaryFund;

            return true;
        }

        private static bool EditAdditionalProfession(AdditionalProfession additionalProfession)
        {
            var dlg = new AdditionalProfessionEditorWindow()
            {
                MainProfession = additionalProfession.Name,
                MainSalary = additionalProfession.MainSalary,
                NormalHours = additionalProfession.NormalHours,
                WorkedHours = additionalProfession.WorkedHours,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            additionalProfession.Name = dlg.MainProfession;
            additionalProfession.MainSalary = dlg.MainSalary;
            additionalProfession.NormalHours = dlg.NormalHours;
            additionalProfession.WorkedHours = dlg.WorkedHours;

            additionalProfession.SummResultSalary();

            return true;
        }

        private static bool EditPenaltie(Penalties penaltie)
        {
            var dlg = new PenaltieEditorWindow()
            {
                NamePenaltie = penaltie.Name,
                Type = penaltie.Type,
                Sum = penaltie.Summ,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            penaltie.Name = dlg.NamePenaltie;
            penaltie.Type = dlg.Type;
            penaltie.Summ = dlg.Sum;

            return true;
        }

    }
}
