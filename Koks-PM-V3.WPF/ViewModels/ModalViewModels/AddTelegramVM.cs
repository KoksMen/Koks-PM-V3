using DevExpress.Mvvm;
using Koks_PM_V3.WPF.Commands.ClosePageCommands;
using Koks_PM_V3.WPF.Commands.ManagerCommands.AccountCommands;
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
    public class AddTelegramVM: BindableBase
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;

        public AddTelegramVM(DataStore dataStore, ModalPageNavigator modalPageNavigator)
        {
            _dataStore = dataStore;
            _modalPageNavigator = modalPageNavigator;
        }

        private string _telegramBotAPI = string.Empty;

        public string TelegramBotAPI
        {
            get { return _telegramBotAPI; }
            set { _telegramBotAPI = value; 
                RaisePropertiesChanged(nameof(TelegramBotAPI)); 
                RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        private string _telegramChatID = string.Empty;

        public string TelegramChatID
        {
            get { return _telegramChatID; }
            set { _telegramChatID = value; 
                RaisePropertiesChanged(nameof(TelegramChatID)); 
                RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        public ICommand SaveCommand => new SaveAddTelegramCommand(_dataStore, _modalPageNavigator, _telegramBotAPI, _telegramChatID);
        public ICommand CancelCommand => new CloseModalPageCommand(_modalPageNavigator);

    }
}
