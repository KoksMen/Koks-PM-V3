using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenModalPageCommand
{
    public class OpenBackupRestorePageCommand : ICommand
    {
        private readonly DataStore _dataStore;
        private readonly ModalPageNavigator _modalPageNavigator;

        public OpenBackupRestorePageCommand(DataStore dataStore, ModalPageNavigator modalPageNavigator)
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
            _modalPageNavigator.SelectedModalPage = new BackupRestoreVM(_dataStore);
        }
    }
}
