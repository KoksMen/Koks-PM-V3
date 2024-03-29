﻿using DevExpress.Mvvm;
using Koks_PM_V3.EntityFramework;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Commands.MainCommands;
using Koks_PM_V3.WPF.Commands.OpenPageCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.MainViewModels
{
    public class LoginVM : BindableBase
    {
        private readonly MainPageNavigator _pageNavigator;
        private readonly LoginDataStore _loginPageDataStore;
        private readonly DataStoreFactory _dataStoreFactory;
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public LoginVM(MainPageNavigator pageNavigator, DataStoreFactory dataStoreFactory, StorageDbContextFactory storageDbContextFactory)
        {
            _pageNavigator = pageNavigator;
            _loginPageDataStore = new LoginDataStore();
            _dataStoreFactory = dataStoreFactory;
            _loginPageDataStore.DataStoreFactory = _dataStoreFactory;
            _storageDbContextFactory = storageDbContextFactory;
        }

        private string _Login;

        public string Login
        {
            get { return _Login; }
            set { _Login = value; _loginPageDataStore.Login = value; RaisePropertiesChanged(nameof(LoginCommand)); }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; _loginPageDataStore.Password = value; RaisePropertiesChanged(nameof(LoginCommand)); }
        }

        public ICommand LoginCommand => new LoginCommand(_pageNavigator, _loginPageDataStore, _dataStoreFactory, _storageDbContextFactory);

        public ICommand OpenRegisterCommand => new OpenRegisterCommand(_pageNavigator, _dataStoreFactory, _storageDbContextFactory);

    }
}
