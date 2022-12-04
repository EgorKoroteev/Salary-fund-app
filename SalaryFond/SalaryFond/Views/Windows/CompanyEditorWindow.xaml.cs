using System;
using System.Windows;
using System.Windows.Input;

namespace SalaryFond.Views.Windows
{
    public partial class CompanyEditorWindow : Window
    {
        #region Название подразделения

        public static readonly DependencyProperty NameCompanyProperty =
            DependencyProperty.Register(nameof(NameCompany),
                typeof(string),
                typeof(CompanyEditorWindow),
                new PropertyMetadata(default(string)));

        public string NameCompany { get => (string)GetValue(NameCompanyProperty); set => SetValue(NameCompanyProperty, value); }

        #endregion

        #region Расположение

        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register(nameof(Location),
                typeof(string),
                typeof(CompanyEditorWindow),
                new PropertyMetadata(default(string)));

        public string Location{ get => (string)GetValue(LocationProperty); set => SetValue(LocationProperty, value); }

        #endregion

        #region Расположение

        public static readonly DependencyProperty PlanningSalaryFundProperty =
            DependencyProperty.Register(nameof(PlanningSalaryFund),
                typeof(int),
                typeof(CompanyEditorWindow),
                new PropertyMetadata(default(int)));

        public int PlanningSalaryFund { get => (int)GetValue(PlanningSalaryFundProperty); set => SetValue(PlanningSalaryFundProperty, value); }

        #endregion
        public CompanyEditorWindow()
        {
            InitializeComponent();
        }

        private void CasePlanningSalaryFound_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}