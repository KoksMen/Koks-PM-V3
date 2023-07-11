using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ModalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenAccountPageCommands
{
    public class OpenTotpPageCommand : ICommand
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;

        public OpenTotpPageCommand(DataStore dataStore, ModalPageNavigator modalPageNavigator)
        {
            _dataStore = dataStore;
            _modalPageNavigator = modalPageNavigator;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try 
            { 
                string totp = _dataStore.UserAccount.userTotpKey;
                if (string.IsNullOrEmpty(totp))
                {
                    _modalPageNavigator.SelectedModalPage = new AddTotpVM(_dataStore, _modalPageNavigator);
                }
                else
                {
                    _modalPageNavigator.SelectedModalPage = new EditTotpVM(_dataStore, _modalPageNavigator);
                }
            } 
            catch 
            {
                throw;
            }
        }
    }
}
