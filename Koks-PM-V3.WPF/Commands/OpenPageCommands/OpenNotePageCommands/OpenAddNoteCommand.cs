using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenNotePageCommands
{
    public class OpenAddNoteCommand : ICommand
    {
        private ModalPageNavigator _modalPageNaviagator;
        private readonly ShowerPageNavigator _viewerNavigator;
        private readonly DataStore _dataStore;
        private readonly List<Category> _categories;
        private Action<object> _execute;

        public OpenAddNoteCommand(ModalPageNavigator modalPageNavigator, ShowerPageNavigator viewerNavigator, DataStore dataStore, List<Category> categories, Action<object> execute)
        {
            _modalPageNaviagator = modalPageNavigator;
            _execute = execute;
            _viewerNavigator = viewerNavigator;
            _dataStore = dataStore;
            _categories = categories;
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
                _execute(parameter);
                OpenAddNotePage();
            }
            catch (Exception)
            {
                throw new NotImplementedException("OpenAddNoteCommand => Execute => Exception");
            }
        }

        private void OpenAddNotePage()
        {
            try
            {
                List<Category> senderCategoryModels = new List<Category>();
                senderCategoryModels.AddRange(_categories);
                senderCategoryModels.RemoveRange(0, 1);
                senderCategoryModels.AddRange(_dataStore.Categories);
                _viewerNavigator.selectedShowerPage = new AddNoteVM(_modalPageNaviagator, _viewerNavigator, _dataStore, senderCategoryModels);
            }
            catch (Exception)
            {
                throw new NotImplementedException("OpenAddNoteCommand => OpenAddNotePage => Exception");
            }
        }
    }
}
