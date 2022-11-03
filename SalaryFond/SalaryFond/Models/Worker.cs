using SalaryFond.Models.Interfaces;
using System;
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
        private float _MainSalary;

        public float MainSalary
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

        private float _RateRUB;

        public float RateRUB
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

        private int _MainResultSalary;

        public int MainResultSalary
        {
            get { return _MainResultSalary; }
            set { _MainResultSalary = value; }
        }

        private int _FinalResultSalary;

        public int FinalResultSalary
        {
            get { return _FinalResultSalary; }
            set { _FinalResultSalary = value; }
        }

        private int _SummPay;

        public int SummPay
        {
            get { return _SummPay; }
            set { _SummPay = value; }
        }

        private int _ResultSalary;

        public int ResultSalary
        {
            get { return _ResultSalary; }
            set { _ResultSalary = value; }
        }

        private int _SummAdditionalProfessions;

        public int SummAdditionalProfessions
        {
            get { return _SummAdditionalProfessions; }
            set { _SummAdditionalProfessions = value; }
        }

        private int _SummPenalties;

        public int SummPenalties
        {
            get { return _SummPenalties; }
            set { _SummPenalties = value; }
        }

        // Можно вводить
        public ObservableCollection<AdditionalProfession> AdditionalProfessions { get; set; } = new ObservableCollection<AdditionalProfession>();

        // Можно вводить
        public ObservableCollection<Penalties> Penalties { get; set; } = new ObservableCollection<Penalties>();

        // Можно вводить
        public ObservableCollection<WorkedDay> WorkedDays { get; set; } = new ObservableCollection<WorkedDay>();


        public void SumResultSalary()
        {
            if (Penalties.Count <= 0)
            {
                Prize = Convert.ToInt32(MainSalary / 10);
            }

            if (MainSalary > 0 && NormalHours > 0)
            {
                RateRUB = MainSalary / NormalHours;
                MainResultSalary = Convert.ToInt32(WorkedHours * (MainSalary / NormalHours) + PrizeBoss + HolidayPay + SickPay);
            }

            if (Penalties.Count <= 0 && Prize > 0)
            {
                MainResultSalary += Prize;
            }
            else if (Penalties.Count > 0 && Prize > 0)
            {
                MainResultSalary -= Prize;
                Prize = 0;
            }

            FinalResultSalary = MainResultSalary;

            if (AdditionalProfessions.Count > 0)
            {
                for (int i = 0; i < AdditionalProfessions.Count; i++)
                {
                    FinalResultSalary += AdditionalProfessions[i].ResultSalary;
                }
            }

            if (Penalties.Count > 0)
            {
                for (int i = 0; i < Penalties.Count; i++)
                {
                    FinalResultSalary -= Penalties[i].Summ;
                }
            }

            SummPay = Prepayment + TransferByCard + RKO + ExecutiveList;

            ResultSalary = FinalResultSalary - SummPay;
        }

        public void CalculateAdditionalAndPenaltie()
        {
            SummAdditionalProfessions = 0;

            SummPenalties = 0;

            if (AdditionalProfessions.Count > 0)
            {
                for (int i = 0; i < AdditionalProfessions.Count; i++)
                {
                    SummAdditionalProfessions += AdditionalProfessions[i].ResultSalary;
                }
            }

            if (Penalties.Count > 0)
            {
                for (int i = 0; i < Penalties.Count; i++)
                {
                    SummPenalties += Penalties[i].Summ;
                }
            }
        }
    }
}
