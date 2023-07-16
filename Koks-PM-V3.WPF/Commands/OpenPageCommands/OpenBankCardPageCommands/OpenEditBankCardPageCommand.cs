using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenBankCardPageCommands
{
    public class OpenEditBankCardPageCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly ShowerPageNavigator _showerPageNavigator;
        private readonly DataStore _dataStore;
        private readonly List<Category> _categoryModels;
        private readonly BankCard _bankCardModel;

        public OpenEditBankCardPageCommand(ModalPageNavigator modalPageNavigator, ShowerPageNavigator showerPageNavigator, DataStore dataStore, List<Category> categoryModels, BankCard bankCardModel)
        {
            _modalPageNavigator = modalPageNavigator;
            _showerPageNavigator = showerPageNavigator;
            _dataStore = dataStore;
            _categoryModels = categoryModels;
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
                _showerPageNavigator.selectedShowerPage = new EditBankCardVM(_modalPageNavigator, _showerPageNavigator, _dataStore, _categoryModels, _bankCardModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
