using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.ManagerCommands.CategoryCommands
{
    public class DeleteCategoryCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly DataStore _dataStore;
        private readonly Category _categoryModel;

        public DeleteCategoryCommand(ModalPageNavigator modalPageNavigator, DataStore dataStore, Category categoryModel)
        {
            _modalPageNavigator = modalPageNavigator;
            _dataStore = dataStore;
            _categoryModel = categoryModel;
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
                _dataStore?.DeleteCategory(_categoryModel.categoryID);
                _modalPageNavigator.SelectedModalPage = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
