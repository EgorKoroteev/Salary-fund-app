using SalaryFond.Models.Interfaces;
using System.Collections.ObjectModel;

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


        private int _Prize;

        public int Prize
        {
            get { return _Prize; }
            set { _Prize = value; }
        }


        // Можно вводить
        private int _PrizeBoss;

        public int PrizeBoss
        {
            get { return _PrizeBoss; }
            set { _PrizeBoss = value; }
        }


        // Можно вводить
        private int _holidayPay;

        public int HolidayPay
        {
            get { return _holidayPay; }
            set { _holidayPay = value; }
        }

        // Можно вводить
        private int _sickPay;

        public int SickPay
        {
            get { return _sickPay; }
            set { _sickPay = value; }
        }

        // Можно вводить
        private int _prepayment;

        public int Prepayment
        {
            get { return _prepayment; }
            set { _prepayment = value; }
        }

        // Можно вводить
        private int _rko;

        public int RKO
        {
            get { return _rko; }
            set { _rko = value; }
        }

        // Можно вводить
        private int _executiveList;

        public int ExecutiveList
        {
            get { return _executiveList; }
            set { _executiveList = value; }
        }

        // Можно вводить
        private int _transferByCard;

        public int TransferByCard
        {
            get { return _transferByCard; }
            set { _transferByCard = value; }
        }

        private int _ResultSalary;

        public int ResultSalary
        {
            get { return _ResultSalary; }
            set { _ResultSalary = value; }
        }

        // Можно вводить
        public ObservableCollection<AdditionalProfession> AdditionalProfessions = new ObservableCollection<AdditionalProfession>();

        // Можно вводить
        public ObservableCollection<Penalties> Penalties = new ObservableCollection<Penalties>();

        // Можно вводить
        public ObservableCollection<WorkedDay> WorkedDays = new ObservableCollection<WorkedDay>();
    }
}
