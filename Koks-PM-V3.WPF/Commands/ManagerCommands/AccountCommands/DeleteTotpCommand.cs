using Koks_PM_V3.Domain.Models;
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
    public class DeleteTotpCommand : ICommand
    {
        private readonly DataStore dataStore;
        private readonly ModalPageNavigator modalPageNavigator;

        public DeleteTotpCommand(DataStore dataStore, ModalPageNavigator modalPageNavigator)
        {
            this.dataStore = dataStore;
            this.modalPageNavigator = modalPageNavigator;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
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
                    userTotpKey: null,
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

                MessageBox.Show("Totp успешно удален");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
