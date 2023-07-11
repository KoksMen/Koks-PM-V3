using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ModalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenAccountPageCommands
{
    public class OpenTelegramPageCommand : ICommand
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;

        public OpenTelegramPageCommand(DataStore dataStore, ModalPageNavigator modalPageNavigator)
        {
            _dataStore = dataStore;
            _modalPageNavigator = modalPageNavigator;
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
                string telegramBotAPI = _dataStore.UserAccount.userTelegramBotApi;
                string telegramChatID = _dataStore.UserAccount.userTelegramChatID;
                if (string.IsNullOrEmpty(telegramBotAPI) || string.IsNullOrEmpty(telegramChatID))
                {
                    _modalPageNavigator.SelectedModalPage = new AddTelegramVM(_dataStore, _modalPageNavigator);
                }
                else
                {
                    _modalPageNavigator.SelectedModalPage = new EditTelegramVM(_dataStore, _modalPageNavigator);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
