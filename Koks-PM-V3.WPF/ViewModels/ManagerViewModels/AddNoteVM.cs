using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenBankCardPageCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.ManagerViewModels
{
    public class AddNoteVM : BindableBase
    {
        private readonly ShowerPageNavigator _viewerNavigator;
        private readonly DataStore _dataStore;
        private readonly List<Category> _categories;

        public AddNoteVM(ShowerPageNavigator viewerNavigator, DataStore dataStore, List<Category> senderCategories)
        {
            _viewerNavigator = viewerNavigator;
            _dataStore = dataStore;
            _categories = senderCategories;
        }

        private string _Name = string.Empty;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertiesChanged(nameof(Name)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }
        private string _Login = string.Empty;

        public string Login
        {
            get { return _Login; }
            set { _Login = value; RaisePropertiesChanged(nameof(Login)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }
        private string _Password = string.Empty;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; RaisePropertiesChanged(nameof(Password)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }
        private Category _Category = new Category(Guid.Empty, "Null", Guid.Empty, DateTime.Now, DateTime.Now);

        public Category SelectedCategory
        {
            get { return _Category; }
            set { _Category = value; RaisePropertiesChanged(nameof(SelectedCategory)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }

        private string _SelectedType = string.Empty;

        public string SelectedType
        {
            get { return _SelectedType; }
            set
            {
                if (value.Contains("Банковская карта"))
                {
                    _viewerNavigator.selectedShowerPage = new AddBankCardVM(_viewerNavigator, _dataStore, _categories);
                }
                else if (value.Contains("Заметка"))
                {
                    _SelectedType = value;
                    RaisePropertiesChanged(nameof(SelectedType));
                }
            }
        }

        private string _URL = string.Empty;

        public string URL
        {
            get { return _URL; }
            set { _URL = value; RaisePropertiesChanged(nameof(URL)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }

        private string _Totp = string.Empty;

        public string Totp
        {
            get { return _Totp; }
            set { _Totp = value; RaisePropertiesChanged(nameof(Totp)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }

        public ICollection<Category> Categories => _categories;

        public ICommand SaveAddCommand => throw new NotImplementedException("AddNoteVM - SaveAddCommand - NotImplementException");
        public ICommand CancelCommand => throw new NotImplementedException("AddNoteVM - CancelCommand - NotImplementException");
    }
}
