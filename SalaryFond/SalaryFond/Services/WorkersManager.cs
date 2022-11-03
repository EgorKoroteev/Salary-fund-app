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

        public void UpdateInformation()
        {
            for (int i = 0; i < _Companies.GetCount(); i++)
            {
                _Companies.GetOne(i).CalculateSalaryFond();
                _Companies.GetOne(i).CalculateNormalHours();
                _Companies.GetOne(i).CalculateWorkedHours();
            }
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
            company.CalculateSalaryFond();
            company.CalculateNormalHours();
            company.CalculateWorkedHours();
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
            worker.CalculateAdditionalAndPenaltie();
            worker.SumResultSalary();
            return true;
        }

        public bool CreatePenaltie(Penalties Penaltie, string WorkerFIO)
        {
            if (Penaltie is null) throw new ArgumentNullException(nameof(Penaltie));
            if (string.IsNullOrWhiteSpace(WorkerFIO)) throw new ArgumentException("Некоректное ФИО сотрудника", nameof(WorkerFIO));

            var worker = _Workers.Get(WorkerFIO);
            if (worker is null) return false;

            
            worker.Penalties.Add(Penaltie);
            worker.CalculateAdditionalAndPenaltie();
            worker.SumResultSalary();
            return true;
        }

        public void Update(Worker Worker) => _Workers.Update(Worker.Id, Worker);

        public bool CreateCompany(Company Company, string MonthName)
        {
            if (Company is null) throw new ArgumentNullException(nameof(Company));
            if (string.IsNullOrWhiteSpace(MonthName)) throw new ArgumentException("Некоректное имя компании", nameof(MonthName));

            var month = _Months.Get(MonthName);
            if (month is null)
            {
                month = new Month { Name = MonthName };
                _Months.Add(month);
            }

            month.Companies.Add(Company);
            _Companies.Add(Company);
            return true;
        }

        public void UpdateCompany(Company Company) => _Companies.Update(Company.Id, Company);

        public void SetCompaniesFromBD(ObservableCollection<Month> months)
        {
            for (int i = 0; i < _Months.GetCount(); i++)
            {
                for (int j = 0; j < _Months.GetOne(i).Companies.Count; j++)
                {
                    _Months.GetOne(i).Companies.Clear();
                }
            }

            _Workers.RemoveAll();
            _Companies.RemoveAll();

            for (int i = 0; i < months.Count; i++)
            {
                if (months[i].Companies.Count > 0)
                {
                    _Months.UpdateBD(months[i], _Months.GetOne(i));
                    for (int j = 0; j < months[i].Companies.Count; j++)
                    {
                        _Companies.Add(months[i].Companies[j]);
                    }

                    for (int t = 0; t < months[i].Companies.Count; t++)
                    {
                        _Companies.Add(months[i].Companies[t]);
                        for (int b = 0; b < months[i].Companies[t].Workers.Count; b++)
                        {
                            _Workers.Add(months[i].Companies[t].Workers[b]);
                        }
                    }
                }
            }
        }

        public void UpdateRepository()
        {

        }
    }
}
