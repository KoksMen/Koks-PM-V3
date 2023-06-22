using DevExpress.Mvvm;
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
    public class AddCategoryVM : BindableBase
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;

        public AddCategoryVM(DataStore dataStore, ModalPageNavigator modalPageNavigator)
        {
            _dataStore = dataStore;
            _modalPageNavigator = modalPageNavigator;
        }

        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertiesChanged(nameof(Name)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        internal ICommand SaveCommand => throw new NotImplementedException("AddCategoryVM - SaveCommand - NotImplementException");
        internal ICommand CancelCommand => throw new NotImplementedException("AddCategoryVM - CloseCommand - NotImplementException");
    }
}
