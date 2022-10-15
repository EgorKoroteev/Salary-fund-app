using SalaryFond.Models;
using SalaryFond.Services.Base;
using System.Linq;

namespace SalaryFond.Services
{
    internal class MonthRepository : RepositoryInMemory<Month>
    {
        public MonthRepository() { }

        protected override void Update(Month Source, Month End)
        {
            throw new System.NotImplementedException();
        }
    }
}
