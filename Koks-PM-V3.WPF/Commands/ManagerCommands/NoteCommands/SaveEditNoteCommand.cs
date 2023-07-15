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
    public class SaveEditNoteCommand : ICommand
    {
        private readonly ShowerPageNavigator _showerPageNavigator;
        private readonly DataStore _dataStore;
        private readonly string _nameNote;
        private readonly string _loginNote;
        private readonly string _passwordNote;
        private readonly Guid _categoryID;
        private readonly string _urlNote;
        private readonly string _totpNote;
        private readonly Note _noteModel;

        public SaveEditNoteCommand(ShowerPageNavigator showerPageNavigator, DataStore dataStore,
            string nameNote, string loginNote, string passwordNote, Guid categoryID, 
            string urlNote, string totpNote, Note noteModel)
        {
            _showerPageNavigator = showerPageNavigator;
            _dataStore = dataStore;
            _nameNote = nameNote;
            _loginNote = loginNote;
            _passwordNote = passwordNote;
            _categoryID = categoryID;
            _urlNote = urlNote;
            _totpNote = totpNote;
            _noteModel = noteModel;
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


            if (_totpNote != _noteModel.noteTotp)
            {
                if (!string.IsNullOrEmpty(_totpNote))
                {
                    try
                    {
                        totp2FA.getTotpNumbers(_totpNote);
                    }
                    catch (ArgumentException)
                    {
                        return false;
                    }
                    return true;
                }

            }   
            if (_categoryID != _noteModel.CategoryID) {
                return true;
            }
            if (_nameNote != _noteModel.noteName) {
                return true;
            }
            if (_loginNote != _noteModel.noteLogin) {
                return true;
            }
            if (_passwordNote != _noteModel.notePassword) {
                return true;
            }
            if (_urlNote != _noteModel.noteUrl) {
                return true;
            }

            return false;
        }

        private bool dataStringWrongValidation(string checkData)
        {
            return string.IsNullOrEmpty(checkData) || checkData.Length < 5;
        }

        public void Execute(object? parameter)
        {
            try
            {
                Note updateNote = new Note(
                    noteID: _noteModel.noteID,
                    noteName: _nameNote,
                    noteLogin: _loginNote,
                    notePassword: _passwordNote,
                    noteUrl: _urlNote,
                    noteTotp: _totpNote,
                    categoryID: _categoryID,
                    userID: _noteModel.userID,
                    modifyDate: DateTime.Now,
                    createDate: _noteModel.createDate);

                _dataStore?.UpdateNote(updateNote);
            }
            catch (Exception ) {
                MessageBox.Show("Произошла ошибка при изменении заметки.");
            }
        }
    }
}
