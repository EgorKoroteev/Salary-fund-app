using SalaryFond.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.Models
{
    internal class Worker : IEntity
    {
        public int Id { get; set; }

        // Можно вводить
        private string _FIO;

        public string FIO
        {
            get { return _FIO; }
            set { _FIO = value; }
        }

        // Можно вводить
        private string _MainProfession;

        public string MainProfession
        {
            get { return _MainProfession; }
            set { _MainProfession = value; }
        }

        // Можно вводить
        private int _MainSalary;

        public int MainSalary
        {
            get { return _MainSalary; }
            set { _MainSalary = value; }
        }

        private int _NormalHours;

        public int NormalHours
        {
            get { return _NormalHours; }
            set { _NormalHours = value; }
        }

        // Можно вводить
        private int _WorkedHours;

        public int WorkedHours
        {
            get { return _WorkedHours; }
            set { _WorkedHours = value; }
        }

        private int _RateRUB;

        public int RateRUB
        {
            get { return _RateRUB; }
            set { _RateRUB = value; }
        }



        // Можно вводить
        private int _PrizeBoss;

        public int PrizeBoss
        {
            get { return _PrizeBoss; }
            set { _PrizeBoss = value; }
        }

        private int _ResultSalary;

        public int ResultSalary
        {
            get { return _ResultSalary; }
            set { _ResultSalary = value; }
        }

        

        // Можно вводить
        public ObservableCollection<AdditionalProfessions> AdditionalProfessions = new ObservableCollection<AdditionalProfessions>();

        // Можно вводить
        public ObservableCollection<Penalties> Penalties = new ObservableCollection<Penalties>();

        // Можно вводить
        public ObservableCollection<WorkedDay> WorkedDays = new ObservableCollection<WorkedDay>();

        /*// Можно вводить
        public List<AdditionalProfessions> AdditionalProfessions = new List<AdditionalProfessions>();

        // Можно вводить
        public List<Penalties> Penalties = new List<Penalties>();

        // Можно вводить
        List<WorkedDay> WorkedDays = new List<WorkedDay>();*/
    }
}
