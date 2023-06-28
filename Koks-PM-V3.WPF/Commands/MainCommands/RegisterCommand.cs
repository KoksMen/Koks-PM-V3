using Koks_PM_V3.Domain.Commands.CreateCommands;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.EntityFramework;
using Koks_PM_V3.EntityFramework.Commands.CreateCommands;
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
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.MainCommands
{
    public class RegisterCommand : ICommand
    {
        private readonly MainPageNavigator _mainPageNavigator;
        private readonly StorageDbContextFactory _storageDbContextFactory;
        private readonly DataStoreFactory _dataStoreFactory;
        private readonly RegisterDataStore _registerPageDataStore;
        private readonly ICreateUser _createUserCommand;

        private string _name => _registerPageDataStore.Name;
        private string _login => _registerPageDataStore.Login;
        private string _password => _registerPageDataStore.Password;
        private string _secondpassword => _registerPageDataStore.ConfirmPassword;

        public RegisterCommand(MainPageNavigator mainPageNavigator, DataStoreFactory dataStoreFactory, StorageDbContextFactory storageDbContextFactory, RegisterDataStore registerPageDataStore)
        {
            this._mainPageNavigator = mainPageNavigator;
            this._storageDbContextFactory = storageDbContextFactory;
            this._registerPageDataStore = registerPageDataStore;
            this._dataStoreFactory = dataStoreFactory;

            _createUserCommand = new CreateUser(_storageDbContextFactory);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (CheckLogin(_login) == false)
                return false;
            else if (CheckLogin(_login) == true)
                if (_name.Length >= 5 && _login.Length >= 5 && _password.Length >= 5 && _secondpassword == _password)
                    return true;

            return false;
        }

        public bool CheckLogin(string Login)
        {
            using (var Context = _storageDbContextFactory.Create())
            {
                var result = Context.Users.FirstOrDefault(x => x.userLogin == Login);
                if (result == null) return true;
            }

            return false;
        }

        public void Execute(object? parameter)
        {
            try
            {
                Thread RegisterThread = new Thread(Register);
                RegisterThread.Start();
            }
            catch (Exception)
            {
                throw new NotImplementedException("Register Command Execute Exception");
            }
        }

        public async void Register()
        {
            try
            {
                User user = new User(Guid.NewGuid(), 
                    _name, _login, HashingModule.HashPassword(_password), 
                    null, null, null, null, 
                    DateTime.Now, DateTime.Now, 
                    new List<Note>(), new List<BankCard>(), new List<Category>());

                await _createUserCommand.Execute(user);


                _mainPageNavigator.SelectedMainPage = new LoginVM(_mainPageNavigator, _dataStoreFactory, _storageDbContextFactory);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Произошла ошибка при регистрации, попробуйте повторить попытку!", "Registration Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
