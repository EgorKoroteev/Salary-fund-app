using System;
using System.Windows;

namespace SalaryFond.Views.Windows
{
    public partial class PenaltieEditorWindow : Window
    {
        #region Название

        public static readonly DependencyProperty NamePenaltieProperty =
            DependencyProperty.Register(nameof(NamePenaltie),
                typeof(string),
                typeof(PenaltieEditorWindow),
                new PropertyMetadata(default(string)));

        public string NamePenaltie { get => (string)GetValue(NamePenaltieProperty); set => SetValue(NamePenaltieProperty, value); }

        #endregion

        #region Тип

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register(nameof(Type),
                typeof(string),
                typeof(PenaltieEditorWindow),
                new PropertyMetadata(default(string)));

        public string Type { get => (string)GetValue(TypeProperty); set => SetValue(TypeProperty, value); }

        #endregion

        #region Сумма штрафа

        public static readonly DependencyProperty SumProperty =
            DependencyProperty.Register(nameof(Sum),
                typeof(int),
                typeof(PenaltieEditorWindow),
                new PropertyMetadata(default(int)));

        public int Sum { get => (int)GetValue(SumProperty); set => SetValue(SumProperty, value); }

        #endregion
        public PenaltieEditorWindow()
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
