using SalaryFond.Models;
using System;
using System.Collections.ObjectModel;

namespace SalaryFond.Services
{
    internal class WorkersManager
    {
        private CompaniesRepository _Companies;
        private WorkersRepository _Workers;
        private MonthRepository _Months;
        private YearsRepository _Years;

        public ObservableCollection<Company> Companies => _Companies.GetAll();
        public ObservableCollection<Worker> Workers => _Workers.GetAll();
        public ObservableCollection<Month> Months => _Months.GetAll();

        public ObservableCollection<YearSalary> Years => _Years.GetAll();

        public WorkersManager(CompaniesRepository Companies, WorkersRepository Workers, MonthRepository Month, YearsRepository Years)
        {
            _Companies = Companies;
            _Workers = Workers;
            _Months = Month;
            _Years = Years;
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

        public bool CreateYear(YearSalary Year)
        {
            if (Year is null) throw new ArgumentNullException(nameof(Year));

            _Years.Add(Year);

            return true;
        }

        public bool Create(string YearNumber, string MonthName, Worker Worker, string CompanyName)
        {
            if (Worker is null) throw new ArgumentNullException(nameof(Worker));
            if (string.IsNullOrWhiteSpace(CompanyName)) throw new ArgumentException("Некоректное имя компании", nameof(CompanyName));
            if (string.IsNullOrWhiteSpace(YearNumber)) throw new ArgumentException("Некоректное имя компании", nameof(YearNumber));
            if (string.IsNullOrWhiteSpace(MonthName)) throw new ArgumentException("Некоректное имя компании", nameof(MonthName));

            var company = _Companies.Get(CompanyName);
            var year = _Years.Get(YearNumber);
            var month = _Months.Get(MonthName);

            if (company is null)
            {
                company = new Company { Name = CompanyName };
                _Companies.Add(company);
            }

            Worker.SumResultSalary();
            Worker.CalculateAdditionalAndPenaltie();
            year.Months[Months.IndexOf(month)].Companies[Companies.IndexOf(company)].Workers.Add(Worker);
            year.Months[Months.IndexOf(month)].Companies[Companies.IndexOf(company)].CalculateSalaryFond();
            year.Months[Months.IndexOf(month)].Companies[Companies.IndexOf(company)].CalculateNormalHours();
            year.Months[Months.IndexOf(month)].Companies[Companies.IndexOf(company)].CalculateWorkedHours();
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

        public bool CreateCompany(Company Company, string MonthName, string YearNumber)
        {
            if (Company is null) throw new ArgumentNullException(nameof(Company));
            if (string.IsNullOrWhiteSpace(MonthName)) throw new ArgumentException("Некоректное имя компании", nameof(MonthName));
            if (string.IsNullOrWhiteSpace(YearNumber)) throw new ArgumentException("Некоректное имя компании", nameof(YearNumber));

            var month = _Months.Get(MonthName);
            if (month is null)
            {
                month = new Month { Name = MonthName };
                _Months.Add(month);
            }

            var year = _Years.Get(YearNumber);
            if (year is null)
            {
                year = new YearSalary { Name = YearNumber };
                _Years.Add(year);
            }

            // Определенный месяц определенного года

            //year.months[4].Companies.Add(Company);
            year.Months[Months.IndexOf(month)].Companies.Add(Company);
            //month.Companies.Add(Company);
            _Companies.Add(Company);
            return true;
        }

        public void UpdateCompany(Company Company) => _Companies.Update(Company.Id, Company);

        public void SetCompaniesFromDictionary(YearSalary selectedYearSalary, Month selectedMonth, ObservableCollection<Company> companies)
        {
            var year = _Years.Get(selectedYearSalary.Name);
            var month = _Months.Get(selectedMonth.Name);

            for (int i = 0; i < companies.Count; i++)
            {
                year.Months[Months.IndexOf(month)].Companies.Add(companies[i]);
                _Companies.Add(companies[i]);
            }
        }

        public void SetCompaniesFromBD(ObservableCollection<YearSalary> years)
        {
            _Years.RemoveAll();

            for (int i = 0; i < _Months.GetCount(); i++)
            {
                for (int j = 0; j < _Months.GetOne(i).Companies.Count; j++)
                {
                    _Months.GetOne(i).Companies.Clear();
                }
            }

            _Workers.RemoveAll();
            _Companies.RemoveAll();

            for (int k = 0; k < years.Count; k++)
            {
                _Years.Add(years[k]);

                
                for (int i = 0; i < years[k].Months.Count; i++)
                {
                    for (int j = 0; j < years[k].Months[i].Companies.Count; j++)
                    {
                        if (_Companies.Get(years[k].Months[i].Companies[j].Name) is null)
                        {
                            _Companies.Add(years[k].Months[i].Companies[j]);
                        }

                        for (int a = 0; a < years[k].Months[i].Companies[j].Workers.Count; a++)
                        {
                            if (_Workers.Get(years[k].Months[i].Companies[j].Workers[a].FIO) is null)
                            {
                                _Workers.Add(years[k].Months[i].Companies[j].Workers[a]);
                            }
                        }
                    }
                }
            }

            
        }

        public void RemoveYear(YearSalary year)
        {
            _Years.Remove(year);
        }

        public void UpdateRepository()
        {

        }
    }
}
