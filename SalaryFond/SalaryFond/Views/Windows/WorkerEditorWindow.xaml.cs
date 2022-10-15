﻿using Magnum.Reflection;
using SalaryFond.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace SalaryFond.Views.Windows
{
    public partial class WorkerEditorWindow : Window
    {
        #region ФИО

        public static readonly DependencyProperty FIOProperty =
            DependencyProperty.Register(nameof(FIO),
                typeof(string),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(string)));

        public string FIO { get => (string)GetValue(FIOProperty); set => SetValue(FIOProperty, value); }

        #endregion

        #region Главная профессия

        public static readonly DependencyProperty MainProfessionProperty =
            DependencyProperty.Register(nameof(MainProfession),
                typeof(string),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(string)));

        public string MainProfession { get => (string)GetValue(MainProfessionProperty); set => SetValue(MainProfessionProperty, value); }

        #endregion

        #region Оклад

        public static readonly DependencyProperty MainSalaryProperty =
            DependencyProperty.Register(nameof(MainSalary),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int MainSalary { get => (int)GetValue(MainSalaryProperty); set => SetValue(MainSalaryProperty, value); }

        #endregion

        #region Норма часы

        public static readonly DependencyProperty NormalHoursProperty =
            DependencyProperty.Register(nameof(NormalHours),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int NormalHours { get => (int)GetValue(NormalHoursProperty); set => SetValue(NormalHoursProperty, value); }

        #endregion

        #region Отработанные часы

        public static readonly DependencyProperty WorkedHoursProperty =
            DependencyProperty.Register(nameof(WorkedHours),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int WorkedHours { get => (int)GetValue(WorkedHoursProperty); set => SetValue(WorkedHoursProperty, value); }

        #endregion

        #region Премия от руководителя

        public static readonly DependencyProperty PrizeBossProperty =
            DependencyProperty.Register(nameof(PrizeBoss),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int PrizeBoss { get => (int)GetValue(PrizeBossProperty); set => SetValue(PrizeBossProperty, value); }

        #endregion

        #region Отпускные

        public static readonly DependencyProperty HolidayPayProperty =
            DependencyProperty.Register(nameof(HolidayPay),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int HolidayPay { get => (int)GetValue(HolidayPayProperty); set => SetValue(HolidayPayProperty, value); }

        #endregion

        #region Больничные

        public static readonly DependencyProperty SickPayProperty =
            DependencyProperty.Register(nameof(SickPay),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int SickPay { get => (int)GetValue(SickPayProperty); set => SetValue(SickPayProperty, value); }

        #endregion

        #region Аванс

        public static readonly DependencyProperty PrepaymentProperty =
            DependencyProperty.Register(nameof(Prepayment),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int Prepayment { get => (int)GetValue(PrepaymentProperty); set => SetValue(PrepaymentProperty, value); }

        #endregion

        #region РКО

        public static readonly DependencyProperty RKOProperty =
            DependencyProperty.Register(nameof(RKO),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int RKO { get => (int)GetValue(RKOProperty); set => SetValue(RKOProperty, value); }

        #endregion

        #region Исполнительный лист

        public static readonly DependencyProperty ExecutiveListProperty =
            DependencyProperty.Register(nameof(ExecutiveList),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int ExecutiveList { get => (int)GetValue(ExecutiveListProperty); set => SetValue(ExecutiveListProperty, value); }

        #endregion

        #region Перечислено р/с

        public static readonly DependencyProperty TransferByCardProperty =
            DependencyProperty.Register(nameof(TransferByCard),
                typeof(int),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(int)));

        public int TransferByCard { get => (int)GetValue(TransferByCardProperty); set => SetValue(TransferByCardProperty, value); }

        #endregion

        /*#region Доп должности

        public static readonly DependencyProperty AdditionalProfessionsProperty =
            DependencyProperty.Register(nameof(AdditionalProfessions),
                typeof(AdditionalProfession),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(ObservableCollection<AdditionalProfession>)));

        public ObservableCollection<AdditionalProfession> AdditionalProfessions { get => (string)GetValue(AdditionalProfessionsProperty); set => SetValue(AdditionalProfessionsProperty, value); }

        #endregion*/



        public WorkerEditorWindow()
        {
            InitializeComponent();
        }
    }
}
