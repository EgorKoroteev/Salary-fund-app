using SalaryFond.Models.Interfaces;
using System.Collections.ObjectModel;

namespace SalaryFond.Models
{
    internal class YearSalary : IEntity
    {
        public int Id { get; set; }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public ObservableCollection<Month> Months { get; set; } = new ObservableCollection<Month>();

        public void NewYear()
        {
            Months = new ObservableCollection<Month> {
                new Month { Name = "Январь" },
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
        new Month { Name = "Декабрь" } };
        }
    }
}
