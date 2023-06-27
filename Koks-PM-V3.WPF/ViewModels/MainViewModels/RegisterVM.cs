using DevExpress.Mvvm;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.MainViewModels
{
    public class RegisterVM : BindableBase
    {
        private readonly MainPageNavigator _pageNavigator;
        private readonly RegisterDataStore _registerPageDataStore;
        private readonly DataStoreFactory _dataStoreFactory;


        public RegisterVM(MainPageNavigator pageNavigator, DataStoreFactory dataStoreFactory)
        {
            _pageNavigator = pageNavigator;
            _registerPageDataStore = new RegisterDataStore();
            _dataStoreFactory = dataStoreFactory;
            _registerPageDataStore.DataStoreFactory = _dataStoreFactory;

        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; _registerPageDataStore.Name = value; RaisePropertiesChanged(nameof(RegisterCommand)); }
        }

        private string _Login;

        public string Login
        {
            get { return _Login; }
            set { _Login = value; _registerPageDataStore.Login = value; RaisePropertiesChanged(nameof(RegisterCommand)); }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; _registerPageDataStore.Password = value; RaisePropertiesChanged(nameof(RegisterCommand)); }
        }
        private string _ConfirmPassword;

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { _ConfirmPassword = value; _registerPageDataStore.ConfirmPassword = value; RaisePropertiesChanged(nameof(RegisterCommand)); }
        }

        private ICommand _registerCommand => throw new NotImplementedException("RegisterVM => RegisterCommand => NotImplementedException");
        public ICommand RegisterCommand
        {
            get { return _registerCommand; }
        }

        private ICommand backLoginCommand => throw new NotImplementedException("RegisterVM => BackLoginCommand => NotImplementedException");


        public ICommand BackLoginCommand
        {
            get { return backLoginCommand; }
        }
        
    }
}
