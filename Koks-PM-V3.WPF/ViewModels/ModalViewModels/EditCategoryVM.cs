using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
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
            _name = category.categoryName;
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertiesChanged(nameof(Name)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        public ICommand SaveCommand => throw new NotImplementedException("EditCategoryVM - SaveCommand - NotImplementException");
        public ICommand CancelCommand => throw new NotImplementedException("EditCategoryVM - CancelCommand - NotImplementException");
        public ICommand DeleteCommand => throw new NotImplementedException("EditCategoryVM - DeleteCommand - NotImplementException");
    }
}
