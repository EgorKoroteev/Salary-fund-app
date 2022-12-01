using System;
using System.Windows;

namespace SalaryFond.Views.Windows
{
    public partial class YearEditorWindow : Window
    {
        public static readonly DependencyProperty YearNumberProperty =
            DependencyProperty.Register(nameof(YearNumber),
                typeof(string),
                typeof(YearEditorWindow),
                new PropertyMetadata(default(string)));

        public string YearNumber { get => (string)GetValue(YearNumberProperty); set => SetValue(YearNumberProperty, value); }

        public YearEditorWindow()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
