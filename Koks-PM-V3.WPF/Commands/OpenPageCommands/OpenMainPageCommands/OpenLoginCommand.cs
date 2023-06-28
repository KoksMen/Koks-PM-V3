using Koks_PM_V3.EntityFramework;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenMainPageCommands
{
    class OpenLoginCommand : ICommand
    {
        private readonly MainPageNavigator _mainPageNavigator;
        private readonly DataStoreFactory _dataStoreFactory;
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public OpenLoginCommand(MainPageNavigator mainPageNavigator, DataStoreFactory dataStoreFactory, StorageDbContextFactory storageDbContextFactory)
        {
            _mainPageNavigator = mainPageNavigator;
            _dataStoreFactory = dataStoreFactory;
            _storageDbContextFactory = storageDbContextFactory;
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
                _mainPageNavigator.SelectedMainPage = new LoginVM(_mainPageNavigator, _dataStoreFactory, _storageDbContextFactory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("OpenLoginCommand => Execute", ex.Message);
            }
        }
    }
}
