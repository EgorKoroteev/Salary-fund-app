using SalaryFond.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SalaryFond.Views.Windows
{
    public partial class ListWorkersWindow : Window
    {
        #region Доп должности

        public static readonly DependencyProperty WorkerListProperty =
            DependencyProperty.Register(nameof(WorkerList),
                typeof(ObservableCollection<Worker>),
                typeof(WorkerEditorWindow),
                new PropertyMetadata(default(ObservableCollection<Worker>)));

        public ObservableCollection<Worker> WorkerList { get => (ObservableCollection<Worker>)GetValue(WorkerListProperty); set => SetValue(WorkerListProperty, value); }

        #endregion
        public ListWorkersWindow()
        {
            InitializeComponent();
        }
    }
}
