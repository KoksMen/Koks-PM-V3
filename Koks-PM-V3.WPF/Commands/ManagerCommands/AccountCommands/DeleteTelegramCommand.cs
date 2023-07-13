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
    public class DeleteTelegramCommand : ICommand
    {
        private readonly DataStore dataStore;
        private ModalPageNavigator modalPageNavigator;
        private User userModel => dataStore.UserAccount;

        public DeleteTelegramCommand(DataStore dataStore, ModalPageNavigator modalPageNavigator)
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
            User userToUpdate = new User
            (
                userID: userModel.userID,
                userName: userModel.userName,
                userLogin: userModel.userLogin,
                userPassword: userModel.userPassword,
                userTotpKey: userModel.userTotpKey,
                userTelegramBotApi: null,
                userTelegramChatID: null,
                userAvatar: userModel.userAvatar,
                modifyDate: DateTime.Now,
                createDate: userModel.createDate,
                userNotes: userModel.userNotes,
                userBankCards: userModel.userBankCards,
                userCategories: userModel.userCategories
            );

            dataStore?.UpdateTelegram(userToUpdate);

            modalPageNavigator.SelectedModalPage = null;
        }
    }
}
