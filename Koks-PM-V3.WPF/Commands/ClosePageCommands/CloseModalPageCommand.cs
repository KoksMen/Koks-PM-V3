using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.ClosePageCommands
{
    public class CloseModalPageCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;

        public CloseModalPageCommand(ModalPageNavigator modalPageNavigator)
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
            _modalPageNavigator.SelectedModalPage = null;
        }
    }
}
