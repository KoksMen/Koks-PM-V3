using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Services;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.ManagerCommands.AccountCommands
{
    public class SaveEditTelegramCommand : ICommand
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly string telegramBotApi;
        private readonly string telegramChatID;
        private User userModel => _dataStore.UserAccount;

        public SaveEditTelegramCommand(DataStore dataStore, ModalPageNavigator modalPageNavigator, string telegramBotApi, string telegramChatID)
        {
            _dataStore = dataStore;
            _modalPageNavigator = modalPageNavigator;
            this.telegramBotApi = telegramBotApi;
            this.telegramChatID = telegramChatID;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (_dataStore.UserAccount.userTelegramBotApi != telegramBotApi)
            {
                return true;
            }
            else if (_dataStore.UserAccount.userTelegramChatID != telegramChatID)
            {
                return true;
            }

            return false;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                TelegramNotificatorService oldTelegramNotificator = new TelegramNotificatorService(_dataStore.UserAccount.userTelegramChatID, _dataStore.UserAccount.userTelegramBotApi, messageType.telegramEditInfo);
                await oldTelegramNotificator.sendTelegramNotification();
                TelegramNotificatorService newTelegramNotificator = new TelegramNotificatorService(telegramChatID, telegramBotApi, messageType.telegramEditInfo);
                await newTelegramNotificator.sendTelegramNotification();

                User userToUpdate = new User
                (
                    userID: userModel.userID,
                    userName: userModel.userName,
                    userLogin: userModel.userLogin,
                    userPassword: userModel.userPassword,
                    userTotpKey: userModel.userTotpKey,
                    userTelegramBotApi: telegramBotApi,
                    userTelegramChatID: telegramChatID,
                    userAvatar: userModel.userAvatar,
                    modifyDate: DateTime.Now,
                    createDate: userModel.createDate,
                    userNotes: userModel.userNotes,
                    userBankCards: userModel.userBankCards,
                    userCategories: userModel.userCategories
                );

                _dataStore?.UpdateTelegram(userToUpdate);

                _modalPageNavigator.SelectedModalPage = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные, попробуйте изменить их!");
            }
        }
    }
}
