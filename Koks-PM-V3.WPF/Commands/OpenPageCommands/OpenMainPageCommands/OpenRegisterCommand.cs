using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands
{
    class OpenRegisterCommand : ICommand
    {
        private readonly MainPageNavigator _mainPageNavigator;
        private readonly DataStoreFactory _dataStoreFactory;

        public OpenRegisterCommand(MainPageNavigator mainPageNavigator, DataStoreFactory dataStoreFactory)
        {
            _mainPageNavigator = mainPageNavigator;
            _dataStoreFactory = dataStoreFactory;
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
                _mainPageNavigator.SelectedMainPage = new RegisterVM(_mainPageNavigator, _dataStoreFactory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("OpenRegisterCommand => Execute", ex.Message);
            }
        }
    }
}
