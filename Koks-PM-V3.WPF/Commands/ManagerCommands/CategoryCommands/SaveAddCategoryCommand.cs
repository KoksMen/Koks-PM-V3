using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.ManagerCommands.CategoryCommands
{
    public class SaveAddCategoryCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly DataStore _dataStore;
        private readonly string _Name;

        public SaveAddCategoryCommand(ModalPageNavigator modalPageNavigator, DataStore dataStore, string name)
        {
            _modalPageNavigator = modalPageNavigator;
            _dataStore = dataStore;
            _Name = name;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (_Name.Length >= 5)
                return true;
            return false;
        }

        public void Execute(object? parameter)
        {
            try
            {
                Category addCategory = new Category(Guid.NewGuid(), _Name, _dataStore.UserAccount.userID, DateTime.Now, DateTime.Now);
                _dataStore?.AddCategory(addCategory);
                _modalPageNavigator.SelectedModalPage = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
