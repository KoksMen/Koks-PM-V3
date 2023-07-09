using Koks_PM_V3.EntityFramework;
using Koks_PM_V3.EntityFramework.DTOs;
using Koks_PM_V3.WPF.Services;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.MainCommands
{
    public class LoginCommand : ICommand
    {
        private readonly MainPageNavigator _pageNavigator;
        private readonly LoginDataStore _loginPageDataStore;
        private readonly DataStoreFactory _dataStoreFactory;
        private readonly StorageDbContextFactory _storageDbContextFactory;

        private string login => _loginPageDataStore.Login;
        private string password => _loginPageDataStore.Password;
        public LoginCommand(MainPageNavigator pageNavigator, LoginDataStore loginPageDataStore, DataStoreFactory dataStoreFactory, StorageDbContextFactory storageDbContextFactory)
        {
            _pageNavigator = pageNavigator;
            _loginPageDataStore = loginPageDataStore;
            _dataStoreFactory = dataStoreFactory;
            _loginPageDataStore.DataStoreFactory = _dataStoreFactory;
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async void Authorize()
        {
            try
            {
                using (var Context = _storageDbContextFactory.Create())
                {
                    string HashedPassword = HashingModule.HashPassword(password);

                    UserDto user = Context.Users.Single(x => x.userLogin == login && x.userPassword == HashedPassword);

                    DataStore dataStore = _dataStoreFactory.Create(user);

                    ManagerVM managerVM = new ManagerVM(dataStore, _pageNavigator);

                    _pageNavigator.SelectedMainPage = managerVM;
                };
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong login or password, change it and try again.","LoginError");
            }
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (login.Length >= 5 && password.Length >= 5)
                return true;
            else
                return false;
        }

        public void Execute(object? parameter)
        {
            try
            {
                Thread LoginThread = new Thread(Authorize);
                LoginThread.Start();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show($"Ошибка при попытке авторизации.", "AuthorizationError", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                throw new NotImplementedException("Ошибка при попытке авторизации.");
            }
        }
    }
}
