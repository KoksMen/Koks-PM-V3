using DevExpress.Mvvm;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Commands.ClosePageCommands;
using Koks_PM_V3.WPF.Commands.ManagerCommands.AccountCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using KoksOtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.ModalViewModels
{
    public class AddTotpVM : BindableBase
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;

        public AddTotpVM(DataStore dataStore, ModalPageNavigator modalPageNavigator)
        {
            _dataStore = dataStore;
            _modalPageNavigator = modalPageNavigator;

            _totpKey = totp2FA.getStringTotpKey(totp2FA.generateNewTotpSecretKey());
        }

        private string _userPassword = string.Empty;

        public string Password
        {
            get { return _userPassword; }
            set { _userPassword = value; RaisePropertiesChanged(nameof(Password)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        private string _totpKey = string.Empty;

        public string TotpKey
        {
            get { return _totpKey; }
            set { _totpKey = value; RaisePropertiesChanged(nameof(TotpKey)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }
        
        private string _totpNumbers = string.Empty;

        public string TotpNumbers
        {
            get { return _totpNumbers; }
            set { _totpNumbers = value; RaisePropertiesChanged(nameof(TotpNumbers)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        public ICommand CopyTotpKey => new RelayCommand(parameter =>
        {
            Clipboard.SetText(TotpKey);
        });

        public ICommand SaveCommand => new SaveAddTotpCommand(_dataStore, _modalPageNavigator, _totpKey, _totpNumbers, _userPassword);
        public ICommand CancelCommand => new CloseModalPageCommand(_modalPageNavigator);
    }
}
