using System.Collections.ObjectModel;
using SalaryFond.Models.Interfaces;

namespace SalaryFond.Models
{
    internal class Month : IEntity
    {
        public int Id { get; set; }

        public ObservableCollection<Company> Companies { get; set; } = new ObservableCollection<Company>();
    }
}

