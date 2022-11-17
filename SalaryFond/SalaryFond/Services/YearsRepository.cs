using SalaryFond.Models;
using SalaryFond.Services.Base;
using System.Linq;

namespace SalaryFond.Services
{
    internal class YearsRepository : RepositoryInMemory<YearSalary>
    {
        public YearSalary Get(string NumberYear) => GetAll().FirstOrDefault(g => g.Name == NumberYear);

        protected override void Update(YearSalary Source, YearSalary End)
        {
            End.Name = Source.Name;
            End.Months.Clear();
            for (int i = 0; i < Source.Months.Count; i++)
            {
                End.Months.Add(Source.Months[i]);
            }
        }

        public void UpdateBD(YearSalary Source, YearSalary End)
        {
            End.Name = Source.Name;
            for (int i = 0; i < Source.Months.Count; i++)
            {
                End.Months.Add(Source.Months[i]);
            }
        }

        public void LoadYears(YearSalary year)
        {
            
        }
    }
}
