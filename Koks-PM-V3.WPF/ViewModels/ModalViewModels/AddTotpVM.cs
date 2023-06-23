using DevExpress.Mvvm;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
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

            throw new NotImplementedException("AddTotpVM => CTOR => NotImplementException => Creating totpkey with 2fa libruary");
        }

        private string _userPassword;

        public string Password
        {
            get { return _userPassword; }
            set { _userPassword = value; RaisePropertiesChanged(nameof(Password)); }
        }

        private string _totpKey;

        public string TotpKey
        {
            get { return _totpKey; }
            set { _totpKey = value; RaisePropertiesChanged(nameof(TotpKey)); }
        }
        
        private string _totpNumbers;

        public string TotpNumbers
        {
            get { return _totpNumbers; }
            set { _totpNumbers = value; RaisePropertiesChanged(nameof(TotpNumbers)); }
        }

        public ICommand CopyTotpKey => new RelayCommand(parameter =>
        {
            Clipboard.SetText(TotpKey);
        });

        public ICommand SaveCommand => throw new NotImplementedException("AddTotpVM => SaveCommand => NotImplementException");
        public ICommand CancelCommand => throw new NotImplementedException("AddTotpVM => CancelCommand => NotImplementException");
    }
}
