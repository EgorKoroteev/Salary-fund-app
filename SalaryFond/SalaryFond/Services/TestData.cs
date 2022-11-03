using SalaryFond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.Services
{
    static class TestData
    {
        public static Month[] Months { get; } = new Month[12] { new Month { Name = "Январь" },
        new Month { Name = "Февраль" },
        new Month { Name = "Март" },
        new Month { Name = "Апрель" },
        new Month { Name = "Май" },
        new Month { Name = "Июнь" },
        new Month { Name = "Июль" },
        new Month { Name = "Август" },
        new Month { Name = "Сентябрь" },
        new Month { Name = "Октябрь" },
        new Month { Name = "Ноябрь" },
        new Month { Name = "Декабрь" }};
        public static Company[] Companies { get; } = Enumerable.Range(1, 10).Select(i => new Company { Name = $"Подразделение {i}" }).ToArray();

        public static Worker[] Workers { get; } = CreateWorkers(Companies);

        private static Worker[] CreateWorkers(Company[] companies)
        {
            var index = 1;
            foreach (var company in companies)
            {
                for (int i = 0; i < 10; i++)
                {
                    company.Workers.Add(new Worker
                    {
                        FIO = $"Фамилия {index} Имя {index} Отчество {index++}"
                    });
                }
            }

            return companies.SelectMany(g => g.Workers).ToArray();
        }
    }
}
