using SalaryFond.Infrastructure.Commads.Base;
using SalaryFond.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace SalaryFond.Infrastructure.Commads
{
    class OpenResultCompaniesCommand : Command
    {
        private ResultCompaniesWindow _window;

        public override bool CanExecute(object parameter) => _window == null;

        public override void Execute(object parameter)
        {
            var window = new ResultCompaniesWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
            };

            _window = window;

            window.Closed += OnWindowClosed;

            window.ShowDialog();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            _window = null;
        }
    }
}
