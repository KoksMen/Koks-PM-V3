using Koks_PM_V3.WPF.Stores.DataStores;
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
    public class OpenPasswordGeneratorPageCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly PasswordGeneratorDataStore _passwordGeneratorDataStore;

        public OpenPasswordGeneratorPageCommand(ModalPageNavigator modalPageNavigator, PasswordGeneratorDataStore passwordGeneratorDataStore)
        {
            _modalPageNavigator = modalPageNavigator;
            _passwordGeneratorDataStore = passwordGeneratorDataStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _modalPageNavigator.SelectedModalPage = new PasswordGeneratorVM(_passwordGeneratorDataStore,_modalPageNavigator);
        }
    }
}
