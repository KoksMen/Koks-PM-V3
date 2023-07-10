using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Commands.ClosePageCommands;
using Koks_PM_V3.WPF.Commands.ManagerCommands.CategoryCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Koks_PM_V3.WPF.ViewModels.ModalViewModels
{
    public class EditCategoryVM : BindableBase
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly Category _category;

        public EditCategoryVM(DataStore dataStore, ModalPageNavigator modalPageNavigator, Category category)
        {
            _dataStore = dataStore;
            _modalPageNavigator = modalPageNavigator;
            _category = category;
            _Name = category.categoryName;
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertiesChanged(nameof(Name)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        public ICommand SaveCommand => new SaveEditCategoryCommand(_modalPageNavigator, _dataStore, _category, _Name);
        public ICommand CancelCommand => new CloseModalPageCommand(_modalPageNavigator);
        public ICommand DeleteCommand => new DeleteCategoryCommand(_modalPageNavigator, _dataStore, _category);
    }
}
