using System.Collections.ObjectModel;
using SalaryFond.Models.Interfaces;

namespace SalaryFond.Models
{
    internal class Month : IEntity
    {
        public int Id { get; set; }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        public ObservableCollection<Company> Companies { get; set; } = new ObservableCollection<Company>();
    }
}

