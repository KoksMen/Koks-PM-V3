using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Commands.ClosePageCommands;
using Koks_PM_V3.WPF.Commands.ManagerCommands.AccountCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Koks_PM_V3.WPF.ViewModels.ModalViewModels
{
    internal class EditUserVM : BindableBase
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;
        private User _user => _dataStore.UserAccount;

        public EditUserVM(DataStore dataStore, ModalPageNavigator modalPageNavigator)
        {
            _dataStore = dataStore;
            _modalPageNavigator = modalPageNavigator;
            _userAvatar = _user.userAvatar;
            _userName = _user.userName;
        }

        private byte[] _userAvatar;

        public byte[] UserAvatar
        {
            get { return _userAvatar; }
            set { _userAvatar = value; RaisePropertiesChanged(nameof(UserAvatar)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertiesChanged(nameof(UserName)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }
        private string _userPassword = string.Empty;

        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; RaisePropertiesChanged(nameof(UserPassword)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        private string _userConfirmPassword = string.Empty;

        public string UserConfirmPassword
        {
            get { return _userConfirmPassword; }
            set { _userConfirmPassword = value; RaisePropertiesChanged(nameof(UserConfirmPassword)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        public ICommand SelectAvatar => new RelayCommand(parameter =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files jpg|*.jpg|jpeg|*.jpeg|png|*.png";
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string fileName = openFileDialog.FileName;
                var img = new BitmapImage(new Uri(fileName));
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(img));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    UserAvatar = ms.ToArray();
                }
            }
        });

        public ICommand SaveCommand => new SaveEditAccountCommand(_dataStore, _modalPageNavigator, _user, _userAvatar, _userName, _userPassword, _userConfirmPassword);
        public ICommand CancelCommand => new CloseModalPageCommand(_modalPageNavigator);
    }
}
