using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Services;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using KoksOtpNet;
using Microsoft.IdentityModel.Tokens;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Koks_PM_V3.WPF.Commands.ManagerCommands.AccountCommands
{
    public class SaveEditTotpCommand : ICommand
    {
        private readonly DataStore dataStore;
        private readonly ModalPageNavigator modalPageNavigator;
        private readonly string totpKey;
        private readonly string totpNumbers;
        private readonly string userPassword;

        public SaveEditTotpCommand(DataStore dataStore, ModalPageNavigator modalPageNavigator, 
            string totpKey, string totpNumbers, string userPassword)
        {
            this.dataStore = dataStore;
            this.modalPageNavigator = modalPageNavigator;
            this.totpKey = totpKey;
            this.totpNumbers = totpNumbers;
            this.userPassword = userPassword;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (userPassword == dataStore.UserAccount.userPassword)
            {
                bool isTotpSuccesfull = totp2FA.verifyTotp(totpKey, totpNumbers);
                if (isTotpSuccesfull)
                {
                    return true;
                }
            }
            return false;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                if (!totp2FA.verifyTotp(totpKey, totpNumbers))
                {
                    throw new ArgumentException();
                }

                if (!dataStore.UserAccount.userTelegramChatID.IsNullOrEmpty() && !dataStore.UserAccount.userTelegramBotApi.IsNullOrEmpty())
                {
                    TelegramNotificatorService telegramNotificator = new TelegramNotificatorService(
                    dataStore.UserAccount.userTelegramChatID,
                    dataStore.UserAccount.userTelegramBotApi,
                    messageType.totpEditDeleteInfo);
                    await telegramNotificator.sendTelegramNotification();
                }
                

                User userToUpdate = new User (
                    userID: dataStore.UserAccount.userID,
                    userName: dataStore.UserAccount.userName,
                    userLogin: dataStore.UserAccount.userLogin,
                    userPassword: dataStore.UserAccount.userPassword,
                    userTotpKey: totpKey,
                    userTelegramBotApi: dataStore.UserAccount.userTelegramBotApi,
                    userTelegramChatID: dataStore.UserAccount.userTelegramChatID,
                    userAvatar: dataStore.UserAccount.userAvatar,
                    modifyDate: DateTime.Now,
                    createDate: dataStore.UserAccount.createDate,
                    userNotes: dataStore.UserAccount.userNotes,
                    userBankCards: dataStore.UserAccount.userBankCards,
                    userCategories: dataStore.UserAccount.userCategories);

                dataStore?.UpdateTotp(userToUpdate);
                modalPageNavigator.SelectedModalPage = null;

                MessageBox.Show("Totp успешно изменен");
            }
            catch (ArgumentException) {
                MessageBox.Show("Время действия totp кода истекло");
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
