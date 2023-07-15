using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using KoksOtpNet;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            if (_categoryID == new Guid("11111111-1111-1111-1111-111111111111") || _categoryID == Guid.Empty) {
                return false;
            }
            if (dataStringWrongValidation(_nameNote)) {
                return false;
            }
            if (dataStringWrongValidation(_loginNote)) {
                return false;
            }
            if (dataStringWrongValidation(_passwordNote)) {
                return false;
            }
            if (!string.IsNullOrEmpty(_totpNote)) {
                try {
                    totp2FA.getTotpNumbers(_totpNote);
                }
                catch (ArgumentException) {
                    return false;
                }
            }

            return true;
        }

        private bool dataStringWrongValidation(string checkData)
        {
            return string.IsNullOrEmpty(checkData) || checkData.Length < 5;
        }

        public void Execute(object? parameter)
        {
            try
            {
                Note addNote = new Note(
                        noteID: Guid.NewGuid(),
                        noteName: _nameNote,
                        noteLogin: _loginNote,
                        notePassword: _passwordNote,
                        noteUrl: _urlNote,
                        noteTotp: _totpNote,
                        categoryID: _categoryID,
                        userID: _dataStore.UserAccount.userID,
                        modifyDate: DateTime.Now,
                        createDate: DateTime.Now
                        );
                _dataStore?.AddNote(addNote);
            }
            catch (Exception) {
                MessageBox.Show("Произошла ошибка при добавлении заметки.");
            }
        }
    }
}
