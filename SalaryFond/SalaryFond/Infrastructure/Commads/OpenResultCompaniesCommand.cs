using SalaryFond.Infrastructure.Commads.Base;
using SalaryFond.Views.Windows;
using System;
using System.Windows;

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
                
            };

            _window = window;

            window.Closed += OnWindowClosed;

            window.Show();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            _window = null;
        }
    }
}
