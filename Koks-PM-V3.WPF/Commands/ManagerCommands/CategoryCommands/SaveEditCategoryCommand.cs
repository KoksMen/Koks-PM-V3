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
    public class SaveEditCategoryCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly DataStore _dataStore;
        private readonly Category _categoryModel;
        private readonly string _categoryName;

        public SaveEditCategoryCommand(ModalPageNavigator modalPageNavigator, DataStore dataStore, Category categoryModel, string categoryName)
        {
            _modalPageNavigator = modalPageNavigator;
            _dataStore = dataStore;
            _categoryModel = categoryModel;
            _categoryName = categoryName;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (_categoryName.Length < 5 || _categoryName == string.Empty || _categoryName == null)
                return false;
            
            if (_categoryName != _categoryModel.categoryName) 
                return true;

            return false;
        }

        public void Execute(object? parameter)
        {
            try
            {
                Category updateCategory = new Category(
                    _categoryModel.categoryID,
                    _categoryName,
                    _categoryModel.userID,
                    DateTime.Now,
                    _categoryModel.createDate
                    );
                _dataStore?.UpdateCategory(updateCategory);
                _modalPageNavigator.SelectedModalPage = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
