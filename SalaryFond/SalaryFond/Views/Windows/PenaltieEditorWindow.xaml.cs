using System.Windows;

namespace SalaryFond.Views.Windows
{
    public partial class PenaltieEditorWindow : Window
    {
        #region Название

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register(nameof(Name),
                typeof(string),
                typeof(AdditionalProfessionEditorWindow),
                new PropertyMetadata(default(string)));

        public string Name { get => (string)GetValue(NameProperty); set => SetValue(NameProperty, value); }

        #endregion

        #region Тип

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register(nameof(Type),
                typeof(string),
                typeof(AdditionalProfessionEditorWindow),
                new PropertyMetadata(default(string)));

        public string Type { get => (string)GetValue(TypeProperty); set => SetValue(TypeProperty, value); }

        #endregion

        #region Сумма штрафа

        public static readonly DependencyProperty SumProperty =
            DependencyProperty.Register(nameof(Sum),
                typeof(int),
                typeof(AdditionalProfessionEditorWindow),
                new PropertyMetadata(default(int)));

        public int Sum { get => (int)GetValue(SumProperty); set => SetValue(SumProperty, value); }

        #endregion
        public PenaltieEditorWindow()
        {
            InitializeComponent();
        }
    }
}
