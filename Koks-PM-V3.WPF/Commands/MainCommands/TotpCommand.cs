using Koks_PM_V3.EntityFramework;
using Koks_PM_V3.EntityFramework.DTOs;
using Koks_PM_V3.WPF.Services;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.MainViewModels;
using KoksOtpNet;
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
    public class TotpCommand : ICommand
    {
        private readonly MainPageNavigator _pageNavigator;
        private readonly DataStoreFactory _dataStoreFactory;
        private readonly UserDto _userDto;
        private string totpNumber;

        public TotpCommand(MainPageNavigator pageNavigator, string totpNumber, 
            DataStoreFactory dataStoreFactory, UserDto userDto)
        {
            _pageNavigator = pageNavigator;
            _dataStoreFactory = dataStoreFactory;
            _userDto = userDto;
            this.totpNumber = totpNumber;
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (totpNumber.Length == 6)
                return true;


            return false;
        }

        public void Execute(object? parameter)
        {
            Thread TotpThread = new Thread(TotpAuthorize);
            TotpThread.Start();
        }

        private async void TotpAuthorize()
        {
            if (totp2FA.verifyTotp(_userDto.userTotpKey, totpNumber))
            {
                DataStore dataStore = _dataStoreFactory.Create(_userDto);

                ManagerVM managerVM = new ManagerVM(dataStore, _pageNavigator);

                _pageNavigator.SelectedMainPage = managerVM;
            }
            else
            {
                MessageBox.Show("Wrong totp code, change it and try again.", "error2FA");
            }
        }

    }
}
