using SalaryFond.Models.Interfaces;
using System.Collections.ObjectModel;

namespace SalaryFond.Models
{
    internal class Year : IEntity
    {
        public int Id { get; set; }

        private int _NumberYear;

        public int NumberYear
        {
            get { return _NumberYear; }
            set { _NumberYear = value; }
        }

        public ObservableCollection<Month> Months { get; set; } = new ObservableCollection<Month>();
    }
}
