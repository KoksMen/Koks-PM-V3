using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ModalViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenCategoryPageCommands
{
    public class OpenEditCategoryPageCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly DataStore _dataStore;
        private readonly Category _categoryModel;

        public OpenEditCategoryPageCommand(ModalPageNavigator modalPageNavigator, DataStore dataStore, Category categoryModel)
        {
            _modalPageNavigator = modalPageNavigator;
            _dataStore = dataStore;
            _categoryModel = categoryModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (_categoryModel == null)
                return false;
            else if (_dataStore.Categories.Any(x => x.categoryID == _categoryModel.categoryID))
                return true;

            return false;
        }

        public void Execute(object? parameter)
        {
            _modalPageNavigator.SelectedModalPage = new EditCategoryVM(_dataStore, _modalPageNavigator, _categoryModel);
        }
    }
}
