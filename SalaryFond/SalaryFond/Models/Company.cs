﻿using SalaryFond.Models.Interfaces;
using System.Collections.ObjectModel;

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

        public void CalculateSalaryFond()
        {
            FactSalaryFund = 0;

            for (int i = 0; i < Workers.Count; i++)
            {
                FactSalaryFund += Workers[i].FinalResultSalary;
            }
        }

        public void CalculateNormalHours()
        {
            NormalHours = 0;

            for (int i = 0; i < Workers.Count; i++)
            {
                NormalHours += Workers[i].NormalHours;
            }
        }

        public void CalculateWorkedHours()
        {
            WorkedHours = 0;

            for (int i = 0; i < Workers.Count; i++)
            {
                WorkedHours += Workers[i].WorkedHours;
            }
        }
    }
}