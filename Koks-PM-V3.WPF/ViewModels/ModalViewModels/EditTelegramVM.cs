﻿using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
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
    public class EditTelegramVM : BindableBase
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;
        private User _userAccount => _dataStore.UserAccount;

        public EditTelegramVM(DataStore dataStore, ModalPageNavigator modalPageNavigator)
        {
            _dataStore = dataStore;
            _modalPageNavigator = modalPageNavigator;

            TelegramBotAPI = _userAccount.userTelegramBotApi;
            TelegramChatID = _userAccount.userTelegramChatID;
        }

        private string _telegramBotAPI = string.Empty;

        public string TelegramBotAPI
        {
            get { return _telegramBotAPI; }
            set { _telegramBotAPI = value; 
                RaisePropertiesChanged(nameof(TelegramBotAPI)); 
                RaisePropertiesChanged(nameof(SaveCommand));
                RaisePropertiesChanged(nameof(DeleteCommand)); }
        }

        private string _telegramChatID = string.Empty;

        public string TelegramChatID
        {
            get { return _telegramChatID; }
            set { _telegramChatID = value; RaisePropertiesChanged(nameof(TelegramChatID)); RaisePropertiesChanged(nameof(SaveCommand)); }
        }

        public ICommand SaveCommand => new SaveEditTelegramCommand(_dataStore, _modalPageNavigator, _telegramBotAPI, _telegramChatID);
        public ICommand CancelCommand => new CloseModalPageCommand(_modalPageNavigator);
        public ICommand DeleteCommand => new DeleteTelegramCommand(_dataStore, _modalPageNavigator);
    }
}
