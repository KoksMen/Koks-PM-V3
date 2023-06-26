using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.ManagerViewModels
{
    public class ShowNoteVM : BindableBase
    {
        private readonly ShowerPageNavigator _viewerNavigator;
        private readonly DataStore _dataStore;
        private readonly Note _note;
        private readonly List<Category> _categories;

        public ShowNoteVM(ShowerPageNavigator viewerNavigator, DataStore dataStore, Note note, List<Category> senderCategories)
        {
            try
            {
                _viewerNavigator = viewerNavigator;
                _dataStore = dataStore;
                _note = note;
                _Category = new List<Category>
                {
                    senderCategories.First(x => x.categoryID == _note.CategoryID)
                };
                _categories = senderCategories;
                if (note.noteUrl != null) _URL = note.noteUrl;
                else if (note.noteUrl == null) _URL = string.Empty;
                if (note.noteTotp != null) _Totp = note.noteTotp;
                else if (note.noteTotp == null) _Totp = string.Empty;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        private string _Name => _note.noteName;

        public string Name
        {
            get { return _Name; }
        }
        private string _Login => _note.noteLogin;

        public string Login
        {
            get { return _Login; }
        }
        private string _Password => _note.notePassword;

        public string Password
        {
            get { return _Password; }
        }

        private string _URL;

        public string URL
        {
            get { return _URL; }
        }

        private string _Totp; 

        public string Totp
        {
            get { return _Totp; throw new NotImplementedException("ShowNoteVM - _Totp - NotImplementException"); }
        }

        private List<Category> _Category;

        public List<Category> SelectedCategory
        {
            get { return _Category; }
        }

        public ICommand EditCommand => throw new NotImplementedException("ShowNoteVM - EditCommand - NotImplementException");
        public ICommand CopyName => new RelayCommand(parameter =>
        {
            Clipboard.SetText(Name);
        });
        public ICommand CopyLogin => new RelayCommand(parameter =>
        {
            Clipboard.SetText(Login);
        });
        public ICommand CopyPassword => new RelayCommand(parameter =>
        {
            Clipboard.SetText(Password);
        });
        public ICommand CopyURL => new RelayCommand(parameter =>
        {
            Clipboard.SetText(URL);
        });
        public ICommand CopyTotp => new RelayCommand(parameter =>
        {
            throw new NotImplementedException("ShowNoteVM - CopyTotp - NotImplementException");
        });
    }
}
