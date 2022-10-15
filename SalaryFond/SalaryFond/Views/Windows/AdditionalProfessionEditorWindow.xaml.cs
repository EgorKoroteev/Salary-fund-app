using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalaryFond.Views.Windows
{
    public partial class AdditionalProfessionEditorWindow : Window
    {
        #region Главная профессия

        public static readonly DependencyProperty MainProfessionProperty =
            DependencyProperty.Register(nameof(MainProfession),
                typeof(string),
                typeof(AdditionalProfessionEditorWindow),
                new PropertyMetadata(default(string)));

        public string MainProfession { get => (string)GetValue(MainProfessionProperty); set => SetValue(MainProfessionProperty, value); }

        #endregion

        #region Оклад

        public static readonly DependencyProperty MainSalaryProperty =
            DependencyProperty.Register(nameof(MainSalary),
                typeof(int),
                typeof(AdditionalProfessionEditorWindow),
                new PropertyMetadata(default(int)));

        public int MainSalary { get => (int)GetValue(MainSalaryProperty); set => SetValue(MainSalaryProperty, value); }

        #endregion

        #region Норма часы

        public static readonly DependencyProperty NormalHoursProperty =
            DependencyProperty.Register(nameof(NormalHours),
                typeof(int),
                typeof(AdditionalProfessionEditorWindow),
                new PropertyMetadata(default(int)));

        public int NormalHours { get => (int)GetValue(NormalHoursProperty); set => SetValue(NormalHoursProperty, value); }

        #endregion

        #region Отработанные часы

        public static readonly DependencyProperty WorkedHoursProperty =
            DependencyProperty.Register(nameof(WorkedHours),
                typeof(int),
                typeof(AdditionalProfessionEditorWindow),
                new PropertyMetadata(default(int)));

        public int WorkedHours { get => (int)GetValue(WorkedHoursProperty); set => SetValue(WorkedHoursProperty, value); }

        #endregion

        public AdditionalProfessionEditorWindow()
        {
            InitializeComponent();
        }
    }
}
