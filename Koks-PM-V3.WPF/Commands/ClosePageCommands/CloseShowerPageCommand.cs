using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.ClosePageCommands
{
    public class CloseShowerPageCommand : ICommand
    {
        private readonly ShowerPageNavigator _showerPageNavigator;
        private readonly IRecord _recordModel;
        private readonly DataStore _dataStore;
        private readonly List<Category> _categories;

        public CloseShowerPageCommand(ShowerPageNavigator showerPageNavigator, IRecord recordModel, DataStore dataStore, List<Category> categories)
        {
            _showerPageNavigator = showerPageNavigator;
            _recordModel = recordModel;
            _dataStore = dataStore;
            _categories = categories;
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
                if (_recordModel == null || _categories == null || _categories.Count == 0)
                {
                    _showerPageNavigator.selectedShowerPage = null;
                }
                else if (_recordModel is Note)
                {
                    _showerPageNavigator.selectedShowerPage = new ShowNoteVM(_showerPageNavigator, _dataStore, _recordModel as Note, _categories);
                }
                else if (_recordModel is BankCard)
                {
                    _showerPageNavigator.selectedShowerPage = new ShowBankCardVM(_showerPageNavigator, _dataStore, _recordModel as BankCard, _categories);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
