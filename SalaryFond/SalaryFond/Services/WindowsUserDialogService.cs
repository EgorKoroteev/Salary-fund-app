using SalaryFond.Models;
using SalaryFond.Services.Interfaces;
using SalaryFond.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalaryFond.Services
{
    internal class WindowsUserDialogService : IUserDialogService
    {
        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            switch (item)
            {
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
                Name = penaltie.Name,
                Type = penaltie.Type,
                Sum = penaltie.Summ,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            penaltie.Name = dlg.Name;
            penaltie.Type = dlg.Type;
            penaltie.Summ = dlg.Sum;

            return true;
        }

    }
}
