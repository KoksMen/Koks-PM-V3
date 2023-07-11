using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ModalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenModalPageCommand
{
    public class OpenAboutPageCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;

        public OpenAboutPageCommand(ModalPageNavigator modalPageNavigator)
        {
            _modalPageNavigator = modalPageNavigator;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _modalPageNavigator.SelectedModalPage = new AboutPageVM(_modalPageNavigator);
        }
    }
}
