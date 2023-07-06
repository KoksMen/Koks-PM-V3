using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.ManagerCommands.NoteCommands
{
    public class SaveAddNoteCommand : ICommand
    {
        private readonly ShowerPageNavigator _showerNavigator;
        private readonly DataStore _dataStore;
        private readonly Guid _categoryID;
        private readonly string _nameNote;
        private readonly string _loginNote;
        private readonly string _passwordNote;
        private readonly string _urlNote;
        private readonly string _totpNote;

        public SaveAddNoteCommand(ShowerPageNavigator showerNavigator, DataStore dataStore, 
            Guid categoryID, string nameNote, string loginNote, 
            string passwordNote, string urlNote, string totpNote)
        {
            _showerNavigator = showerNavigator;
            _dataStore = dataStore;
            _categoryID = categoryID;
            _nameNote = nameNote;
            _loginNote = loginNote;
            _passwordNote = passwordNote;
            _urlNote = urlNote;
            _totpNote = totpNote;
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
                Note addNote = new Note(
                        Guid.NewGuid(),
                        _nameNote,
                        _loginNote,
                        _passwordNote,
                        _urlNote,
                        _totpNote,
                        _categoryID,
                        _dataStore.UserAccount.userID,
                        DateTime.Now,
                        DateTime.Now
                        );
                _dataStore?.AddNote(addNote);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
