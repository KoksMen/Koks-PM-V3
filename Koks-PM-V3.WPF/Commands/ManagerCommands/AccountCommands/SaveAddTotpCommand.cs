using Koks_PM_V3.Domain.Models;
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
using Windows.UI.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Koks_PM_V3.WPF.Commands.ManagerCommands.AccountCommands
{
    public class SaveAddTotpCommand : ICommand
    {
        private readonly DataStore dataStore;
        private readonly ModalPageNavigator modalPageNavigator;
        private readonly string totpKey;
        private readonly string totpNumbers;
        private readonly string userPassword;

        public SaveAddTotpCommand(DataStore dataStore, ModalPageNavigator modalPageNavigator, string totpKey, string totpNumbers, string userPassword)
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

        public void Execute(object? parameter)
        {
            try
            {
                User userToUpdate = new User
                (
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
                    userCategories: dataStore.UserAccount.userCategories
                );

                dataStore?.UpdateTotp(userToUpdate);
                modalPageNavigator.SelectedModalPage = null;

                MessageBox.Show("Totp успешно добавлен на аккаунт");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
