using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.Models
{
    public class AdditionalProfession
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

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

        private int _ResultSalary;

        public int ResultSalary
        {
            get { return _ResultSalary; }
            set { _ResultSalary = value; }
        }

        public void SummResultSalary()
        {
            if (MainSalary > 0 && NormalHours > 0)
            {
                RateRUB = MainSalary / NormalHours;
                ResultSalary = WorkedHours * (MainSalary / NormalHours);
            }
        }

        public AdditionalProfession() { }
    }
}
