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
    public class OpenEditNotePageCommand : ICommand
    {
        private readonly ModalPageNavigator _modalPageNavigator;
        private readonly ShowerPageNavigator _showerPageNavigator;
        private readonly DataStore _dataStore;
        private readonly List<Category> _categoryModels;
        private readonly Note _noteModel;

        public OpenEditNotePageCommand(ModalPageNavigator modalPageNavigator, ShowerPageNavigator showerPageNavigator, DataStore dataStore, List<Category> categoryModels, Note noteModel)
        {
            _modalPageNavigator = modalPageNavigator;
            _showerPageNavigator = showerPageNavigator;
            _dataStore = dataStore;
            _categoryModels = categoryModels;
            _noteModel = noteModel;
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
                _showerPageNavigator.selectedShowerPage = new EditNoteVM(_modalPageNavigator, _showerPageNavigator, _dataStore, _categoryModels, _noteModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
