using SalaryFond.Models;
using SalaryFond.Services.Base;
using System.Linq;

namespace SalaryFond.Services
{
    internal class MonthRepository : RepositoryInMemory<Month>
    {
        public MonthRepository() : base(TestData.Months) { }

        public Month Get(string MonthName) => GetAll().FirstOrDefault(g => g.Name == MonthName);

        protected override void Update(Month Source, Month End)
        {
            End.Name = Source.Name;
        }
    }
}
