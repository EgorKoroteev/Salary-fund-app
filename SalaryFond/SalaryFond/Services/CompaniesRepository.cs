using SalaryFond.Models;
using SalaryFond.Services.Base;
using System.Linq;


namespace SalaryFond.Services
{
    internal class CompaniesRepository : RepositoryInMemory<Company>
    {
        public CompaniesRepository() { }

        public Company Get(string CompanyName) => GetAll().FirstOrDefault(g => g.Name == CompanyName);

        protected override void Update(Company Source, Company Destination)
        {
            Destination.Name = Source.Name;
            Destination.Location = Source.Location;
            Destination.NormalHours = Source.NormalHours;
            Destination.WorkedHours = Source.WorkedHours;
            Destination.PlanningSalaryFund = Source.PlanningSalaryFund;
            Destination.FactSalaryFund = Source.FactSalaryFund;
        }
    }
}
