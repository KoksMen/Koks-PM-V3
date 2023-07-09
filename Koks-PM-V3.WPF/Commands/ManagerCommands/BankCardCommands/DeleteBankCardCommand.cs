using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.ManagerCommands.BankCardCommands
{
    public class DeleteBankCardCommand : ICommand
    {
        private readonly ShowerPageNavigator _showerPageNavigator;
        private readonly DataStore _dataStore;
        private readonly BankCard _bankCardModel;

        public DeleteBankCardCommand(ShowerPageNavigator showerPageNavigator, DataStore dataStore, BankCard bankCardModel)
        {
            _showerPageNavigator = showerPageNavigator;
            _dataStore = dataStore;
            _bankCardModel = bankCardModel;
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
                _dataStore.DeleteBankCard(_bankCardModel.cardID);
                _showerPageNavigator.selectedShowerPage = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
