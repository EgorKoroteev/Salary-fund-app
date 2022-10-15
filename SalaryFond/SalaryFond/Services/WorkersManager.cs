using SalaryFond.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.Services
{
    internal class WorkersManager
    {
        private CompaniesRepository _Companies;
        private WorkersRepository _Workers;
        private MonthRepository _Months;

        public ObservableCollection<Company> Companies => _Companies.GetAll();
        public ObservableCollection<Worker> Workers => _Workers.GetAll();
        public ObservableCollection<Month> Months => _Months.GetAll();

        public WorkersManager(CompaniesRepository Companies, WorkersRepository Workers, MonthRepository Month)
        {
            _Companies = Companies;
            _Workers = Workers;
            _Months = Month;
        }

        public bool Create(Worker Worker, string CompanyName)
        {
            if (Worker is null) throw new ArgumentNullException(nameof(Worker));
            if (string.IsNullOrWhiteSpace(CompanyName)) throw new ArgumentException("Некоректное имя компании", nameof(CompanyName));

            var company = _Companies.Get(CompanyName);
            if (company is null)
            {
                company = new Company { Name = CompanyName };
                _Companies.Add(company);
            }

            company.Workers.Add(Worker);
            Worker.SumResultSalary();
            _Workers.Add(Worker);
            return true;
        }

        public bool CreateAdditionalProfession(AdditionalProfession AdditionalProfession, string WorkerFIO)
        {
            if (AdditionalProfession is null) throw new ArgumentNullException(nameof(AdditionalProfession));
            if (string.IsNullOrWhiteSpace(WorkerFIO)) throw new ArgumentException("Некоректное ФИО сотрудника", nameof(WorkerFIO));

            var worker = _Workers.Get(WorkerFIO);
            if (worker is null) return false;

            AdditionalProfession.SummResultSalary();
            worker.AdditionalProfessions.Add(AdditionalProfession);
            return true;
        }

        public void Update(Worker Worker) => _Workers.Update(Worker.Id, Worker);

        public bool CreateCompany(Company Company)
        {
            if (Company is null) throw new ArgumentNullException(nameof(Company));

            _Companies.Add(Company);
            return true;
        }

        public void UpdateCompany(Company Company) => _Companies.Update(Company.Id, Company);
    }
}
