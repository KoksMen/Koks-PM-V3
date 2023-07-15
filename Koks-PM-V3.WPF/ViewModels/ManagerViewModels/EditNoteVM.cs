using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.EntityFramework.Commands.DeleteCommands;
using Koks_PM_V3.WPF.Commands.ClosePageCommands;
using Koks_PM_V3.WPF.Commands.ManagerCommands.NoteCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.ManagerViewModels
{
    public class EditNoteVM : BindableBase
    {
        private readonly ShowerPageNavigator _showerPageNavigator;
        private readonly DataStore _dataStore;
        private readonly List<Category> _categories;
        private readonly Note _note;

        public EditNoteVM(ShowerPageNavigator viewerNavigator, DataStore dataStore, List<Category> senderCategories, Note note)
        {
            _showerPageNavigator = viewerNavigator;
            _dataStore = dataStore;
            _categories = senderCategories;
            _note = note;
            Name = _note.noteName;
            Login = _note.noteLogin;
            Password = _note.notePassword;
            SelectedCategory = _categories.First(x => x.categoryID == _note.CategoryID);
            if (!string.IsNullOrEmpty(note.noteUrl)) {
                URL = _note.noteUrl;
            }
            else {
                URL = string.Empty;
            }
            if (!string.IsNullOrEmpty(note.noteTotp)) {
                Totp = _note.noteTotp;
            }
            else {
                Totp = string.Empty;
            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertiesChanged(nameof(Name)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }
        private string _Login;

        public string Login
        {
            get { return _Login; }
            set { _Login = value; RaisePropertiesChanged(nameof(Login)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; RaisePropertiesChanged(nameof(Password)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }
        private Category _Category;

        public Category SelectedCategory
        {
            get { return _Category; }
            set { _Category = value; RaisePropertiesChanged(nameof(SelectedCategory)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }
        private string _URL;

        public string URL
        {
            get { return _URL; }
            set { _URL = value; RaisePropertiesChanged(nameof(URL)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }

        private string _Totp = string.Empty;

        public string Totp
        {
            get { return _Totp; }
            set { _Totp = value; RaisePropertiesChanged(nameof(Totp)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }

        public ICollection<Category> Categories => _categories;

        public ICommand SaveEditCommand => new SaveEditNoteCommand(_showerPageNavigator, _dataStore, _Name, _Login, _Password, _Category.categoryID, _URL, _Totp, _note);
        public ICommand CancelCommand => new CloseShowerPageCommand(_showerPageNavigator, _note, _dataStore, _categories);
        public ICommand DeleteCommand => new DeleteNoteCommand(_showerPageNavigator, _dataStore, _note);
    }
}
