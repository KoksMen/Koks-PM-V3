using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Services;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.ManagerCommands.AccountCommands
{
    public class SaveEditAccountCommand : ICommand
    {
        private readonly DataStore dataStore;
        private readonly ModalPageNavigator modalPageNavigator;
        private User userModel;
        private byte[] userAvatar;
        private string userName;
        private string userPassword;
        private string userSecondPassword;

        public SaveEditAccountCommand(DataStore dataStore, ModalPageNavigator modalPageNavigator, User userModel, 
            byte[] userAvatar, string userName, string userPassword, string userSecondPassword)
        {
            this.dataStore = dataStore;
            this.modalPageNavigator = modalPageNavigator;
            this.userModel = userModel;
            this.userAvatar = userAvatar;
            this.userName = userName;
            this.userPassword = userPassword;
            this.userSecondPassword = userSecondPassword;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            //Без изменения пароля
            if (userPassword == string.Empty && userSecondPassword == string.Empty)
            {
                if (userAvatar != userModel.userAvatar)
                    return true;
                else if (userName != userModel.userName)
                    return true;
            }
            //С изменением пароля
            else if (userPassword != string.Empty)
            {
                if (userPassword.Length >= 5 && userPassword == userSecondPassword) 
                {
                    if (userName.Length >= 5 && ((userAvatar == userModel.userAvatar) || (userAvatar != userModel.userAvatar && userAvatar != null)))
                    {
                        if ((userName != userModel.userName) || (userName == userModel.userName))
                        {
                            return true;
                        }
                        else if ((userAvatar != userModel.userAvatar) || (userAvatar == userModel.userAvatar))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                if (userPassword != string.Empty)
                {
                    if (!userModel.userTelegramBotApi.IsNullOrEmpty() && !userModel.userTelegramChatID.IsNullOrEmpty())
                    {
                        TelegramNotificatorService telegramNotificator = new TelegramNotificatorService
                        (
                            userModel.userTelegramChatID,
                            userModel.userTelegramBotApi,
                            messageType.editPasswordInfo
                        );

                        await telegramNotificator.sendTelegramNotification();
                    } 
                }

                User userToUpdate = new User
                (
                    userID: userModel.userID,
                    userName: userName,
                    userLogin: userModel.userLogin,
                    userPassword: userPassword.IsNullOrEmpty() ? userModel.userPassword : userPassword,
                    userTotpKey: userModel.userTotpKey,
                    userTelegramBotApi: userModel.userTelegramBotApi,
                    userTelegramChatID: userModel.userTelegramChatID,
                    userAvatar: userAvatar,
                    modifyDate: DateTime.Now,
                    createDate: userModel.createDate,
                    userNotes: userModel.userNotes,
                    userBankCards: userModel.userBankCards,
                    userCategories: userModel.userCategories
                );

                dataStore?.UpdateUser(userToUpdate);
                modalPageNavigator.SelectedModalPage = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
