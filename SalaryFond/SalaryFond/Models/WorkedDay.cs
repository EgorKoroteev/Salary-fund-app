using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.Models
{
    internal class WorkedDay
    {
        public DateOnly Day;

        private string _NameProfession;

        public string NameProfession
        {
            get { return _NameProfession; }
            set { _NameProfession = value; }
        }
    }
}
