using SalaryFond.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.Models
{
    internal class Company : IEntity
    {
        public int Id { get; set; }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Location;

        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        private int _NormalHours;

        public int NormalHours
        {
            get { return _NormalHours; }
            set { _NormalHours = value; }
        }

        private int _WorkedHours;

        public int WorkedHours
        {
            get { return _WorkedHours; }
            set { _WorkedHours = value; }
        }

        private int _PlannigSalaryFund;

        public int PlanningSalaryFund
        {
            get { return _PlannigSalaryFund; }
            set { _PlannigSalaryFund = value; }
        }

        private int _FactSalaryFund;

        public int FactSalaryFund
        {
            get { return _FactSalaryFund; }
            set { _FactSalaryFund = value; }
        }

        public ObservableCollection<Worker> Workers { get; set; } = new ObservableCollection<Worker>();

        //public List<Worker> Workers = new List<Worker>();
    }
}

