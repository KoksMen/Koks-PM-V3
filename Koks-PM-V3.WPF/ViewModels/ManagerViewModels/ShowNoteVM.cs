using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenNotePageCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using KoksOtpNet;
using Microsoft.IdentityModel.Tokens;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Windows.ApplicationModel.Background;

namespace Koks_PM_V3.WPF.ViewModels.ManagerViewModels
{
    public class ShowNoteVM : BindableBase
    {
        private DispatcherTimer timer;
        private readonly ShowerPageNavigator _viewerNavigator;
        private readonly DataStore _dataStore;
        private readonly Note _note;
        private readonly List<Category> _categories;

        public ShowNoteVM(ShowerPageNavigator viewerNavigator, DataStore dataStore, Note note, List<Category> senderCategories)
        {
            _viewerNavigator = viewerNavigator;
            _dataStore = dataStore;
            _note = note;
            _SelectedCategory = _SelectedCategory = new List<Category>
            {
                senderCategories.First(x => x.categoryID == _note.CategoryID)
            };
            _categories = senderCategories;
            if (!string.IsNullOrEmpty(note.noteUrl)) {
                _URL = note.noteUrl;
            }
            else {
                _URL = string.Empty;
            }

            if (!string.IsNullOrEmpty(note.noteTotp))
            {
                _Totp = note.noteTotp;
                StartTimer();
                Tick(null,null);
                RaisePropertiesChanged(nameof(isHaveTotp));
            }
            else {
                _Totp = string.Empty;
                _isHaveTotp = false;
                RaisePropertiesChanged(nameof(isHaveTotp));
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
            get { return _Totp; }
        }

        private string _TotpCode = string.Empty;
        public string TotpCode 
        { 
            get { return _TotpCode; } 
            private set 
            { 
                _TotpCode = value; 
                RaisePropertiesChanged(nameof(TotpCode)); 
            } 
        }

        private string _remainSeconds = string.Empty;
        public string RemainSeconds 
        { 
            get { return _remainSeconds; } 
            private set 
            { 
                _remainSeconds = value; 
                RaisePropertiesChanged(nameof(RemainSeconds));
                RaisePropertiesChanged(nameof(isHaveTotp));
            } 
        }

        public string modifyDate => _note.modifyDate.ToString("G");
        public string createDate => _note.createDate.ToString("G");

        private List<Category> _SelectedCategory;
        public List<Category> SelectedCategory
        {
            get { return _SelectedCategory; }
        }


        private bool _isHaveTotp = false;
        public bool isHaveTotp
        {
            get { return _isHaveTotp; }
        }

        private void StartTimer() 
        {
            timer = new DispatcherTimer 
            {
                Interval = new TimeSpan(0, 0, 0, 1, 0)
            };
            timer.Tick += new EventHandler(Tick);
            timer.Start();
        }

        private void StopTimer()
        {
            if (timer != null) {
                timer.Stop();
                timer.Tick -= new EventHandler(Tick);
                timer = null;
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            if (!Totp.IsNullOrEmpty()) 
            {
                try 
                {
                    RemainSeconds = (totp2FA.getTotpSeconds(Totp)).ToString();
                    TotpCode = totp2FA.getTotpNumbers(Totp);
                    _isHaveTotp = true;
                }
                catch (Exception)
                {
                    _isHaveTotp = false;
                    RaisePropertiesChanged(nameof(isHaveTotp));
                    TotpCode = string.Empty;
                    StopTimer();
                }
            }
        }

        #region Commands
        private ICommand _editCommand => new OpenEditNotePageCommand(_viewerNavigator, _dataStore, _categories, _note);
        public ICommand EditCommand => new RelayCommand(parameter => 
        {
            StopTimer();
            _editCommand.Execute(this);
        }, 
        parameter => true);
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
            Clipboard.SetText(TotpCode);
        });
        #endregion
    }
}
