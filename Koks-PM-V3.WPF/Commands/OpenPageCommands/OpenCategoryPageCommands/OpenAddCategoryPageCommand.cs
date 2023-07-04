using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ModalViewModels;
using Koks_PM_V3.WPF.Views.ModalPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenCategoryPageCommands
{
    public class OpenAddCategoryPageCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly DataStore _dataStore;

        public OpenAddCategoryPageCommand(ModalPageNavigator modalPageNavigator, DataStore dataStore)
        {
            _modalPageNavigator = modalPageNavigator;
            _dataStore = dataStore;
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
                _modalPageNavigator.SelectedModalPage = new AddCategoryVM(_dataStore, _modalPageNavigator);
            }
            catch (Exception)
            {
                throw new Exception("OpenAddCategoryCommand => Execute => Exception");
            }
        }
    }
}
