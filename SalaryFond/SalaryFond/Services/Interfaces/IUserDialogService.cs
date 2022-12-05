using SalaryFond.Models;
using System.Collections.ObjectModel;

namespace SalaryFond.Services.Interfaces
{
    internal interface IUserDialogService
    {
        bool Edit(object item);

        bool EditWorker(Worker worker, Company selectedCompany);

        void ShowInformation(string Information, string Caption);

        void ShowWarning(string Message, string Caption);

        void ShowError(string Message, string Caption);

        bool Confirm(string Message, string Caption, bool Exclamation = false);

        bool OpenFile(string Title, out string SelectedFile, string Filter = "Все файлы (*.*)|*.*");

        bool SaveFile(string Title, out string SelectedFile, string FileExt, string Filter = "Все файлы (*.*)|*.*");

        void OpenWorkerList(ObservableCollection<Worker> workers);
    }
}