using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenCategoryPageCommands;
using Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenNotePageCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Koks_PM_V3.WPF.ViewModels.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.MainViewModels
{
    public class ManagerVM : BindableBase
    {
        private readonly DataStore _dataStore;
        private readonly MainPageNavigator _pageNavigator;
        private readonly ShowerPageNavigator _viewerNavigator;
        private readonly ModalPageNavigator _modalPageNavigator;

        public BindableBase ShowerManagerSelectedPage => _viewerNavigator.selectedShowerPage;
        public BindableBase SelectedModalPage => _modalPageNavigator.SelectedModalPage;
        public bool IsModalOpen => SelectedModalPage != null;
        private void modalPageChanged() { RaisePropertiesChanged(nameof(SelectedModalPage)); RaisePropertiesChanged(nameof(IsModalOpen)); }
        private void ShowerPageChangedEvent() => RaisePropertiesChanged(nameof(ShowerManagerSelectedPage));

        public string AccountName => _dataStore.UserAccount.userName;
        public byte[] AccountAvatar => _dataStore.UserAccount.userAvatar;

        private ICollectionView _Records;
        public ICollectionView Records
        {
            get { return _Records; }
            set { _Records = value; RaisePropertiesChanged(nameof(Records)); }
        }

        private IRecord _SelectedRecord;
        public IRecord SelectedRecord
        {
            get { return _SelectedRecord; }
            set { _SelectedRecord = value; ShowRecord(); RaisePropertyChanged(nameof(SelectedRecord)); }
        }

        //public ICollectionView Categories => CollectionViewSource.GetDefaultView(_dataStore.Categories);
        private ICollectionView _Categories;
        public ICollectionView Categories
        {
            get { return _Categories; }
            set { _Categories = value; RaisePropertiesChanged(nameof(Categories)); }
        }

        public ICollectionView StandartCategories => CollectionViewSource.GetDefaultView(_StandartCategories);
        public List<Category> _StandartCategories = new List<Category>
        {
            new Category(new Guid("11111111-1111-1111-1111-111111111111"), "Все элементы", Guid.Empty, DateTime.UtcNow.Date,DateTime.UtcNow.Date),
            new Category(new Guid("22222222-2222-2222-2222-222222222222"), "Без категории", Guid.Empty,DateTime.UtcNow.Date,DateTime.UtcNow.Date),
            new Category(new Guid("33333333-3333-3333-3333-333333333333"), "Избранное", Guid.Empty, DateTime.UtcNow.Date, DateTime.UtcNow.Date),
        };

        private Category _StandartCategory;
        public Category StandartCategory
        {
            get { return _StandartCategory; }
            set
            {
                _StandartCategory = value;
                if (value != null)
                {
                    if (FilterCategory != null) FilterCategory = null;
                }
                RaisePropertiesChanged(nameof(StandartCategory));
                Records.Refresh();
            }
        }

        private Category _FilterCategory;
        public Category FilterCategory
        {
            get { return _FilterCategory; }
            set
            {
                _FilterCategory = value;
                if (value != null)
                {
                    if (StandartCategory != null) StandartCategory = null;
                }
                RaisePropertiesChanged(nameof(FilterCategory));
                RaisePropertiesChanged(nameof(OpenEditCategoryCommand));
                Records.Refresh();
            }
        }

        private string _FilterText = string.Empty;
        public string FilterText
        {
            get { return _FilterText; }
            set
            {
                _FilterText = value;
                RaisePropertiesChanged(nameof(FilterText));
                Records.Refresh();
            }
        }

        public ICommand OpenAddNoteCommand => new OpenAddNoteCommand(_viewerNavigator, _dataStore, _StandartCategories, x => { if (SelectedRecord != null) SelectedRecord = null; });
        public ICommand OpenAddBankCardCommand => throw new NotImplementedException("ManagerVM => OpenAboutModalPage => NotImplementException");
        public ICommand OpenAddCategoryCommand => new OpenAddCategoryPageCommand(_modalPageNavigator, _dataStore);
        public ICommand OpenEditCategoryCommand => throw new NotImplementedException("ManagerVM => OpenAboutModalPage => NotImplementException");
        public ICommand OpenAccountEditPage => throw new NotImplementedException("ManagerVM => OpenAboutModalPage => NotImplementException");
        public ICommand OpenAccountTotpPage => throw new NotImplementedException("ManagerVM => OpenAboutModalPage => NotImplementException");
        public ICommand OpenAccountTelegramPage => throw new NotImplementedException("ManagerVM => OpenAboutModalPage => NotImplementException");
        public ICommand OpenAboutModalPage => throw new NotImplementedException("ManagerVM => OpenAboutModalPage => NotImplementException");
        public ICommand ExitCommand => new RelayCommand(parameter => { _pageNavigator.SelectedMainPage = null; });

        public ManagerVM(DataStore dataStore, MainPageNavigator pageNavigator)
        {
            _dataStore = dataStore;
            _dataStore.noteUpdatedAdded += noteUpdateAddEvent;
            _dataStore.bankcardUpdatedAdded += bankCardUpdAddEvent;
            _dataStore.recordDelete += recordDeleteEvent;
            _dataStore.categoryUpdateAddDelete += categoryUpdAddDelEvent;
            _dataStore.userUpdate += userAccountUpdEvent;

            //List<Category> allCategories = _dataStore.Categories;
            Categories = CollectionViewSource.GetDefaultView(_dataStore.Categories);

            /*List<IRecord> allRecords = _dataStore.Notes.Cast<IRecord>()
                .Concat(_dataStore.BankCards.Cast<IRecord>())
                .ToList();*/
            //Records = CollectionViewSource.GetDefaultView(allRecords);
            Records = CollectionViewSource.GetDefaultView(dataStore.Notes.Cast<IRecord>().Concat(_dataStore.BankCards.Cast<IRecord>()).ToList());

            Records.Filter = RecordFilter;

            _pageNavigator = pageNavigator;
            _viewerNavigator = new ShowerPageNavigator();
            _viewerNavigator.ShowerPageChanged += ShowerPageChangedEvent; ;
            _modalPageNavigator = new ModalPageNavigator();
            _modalPageNavigator.ModalPageChanged += modalPageChanged;
            _StandartCategory = _StandartCategories[0];
            Records.Refresh();
        }


        private void userAccountUpdEvent()
        {
            try
            {
                RaisePropertiesChanged(nameof(AccountName));
                RaisePropertiesChanged(nameof(AccountAvatar));
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show($"Ошибка при вызове события изменения аккаунта.", "AccountEventError", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        private void categoryUpdAddDelEvent()
        {
            try
            {
                Categories = CollectionViewSource.GetDefaultView(_dataStore.Categories);
                RaisePropertiesChanged(nameof(Categories));
                StandartCategory = _StandartCategories[0];
                FilterCategory = null;
                RaisePropertiesChanged(nameof(FilterCategory));
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show($"Ошибка при вызове события изменения категории.", "CategoryEventError", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        private void recordDeleteEvent()
        {
            try
            {
                /*List<IRecord> allRecords = _dataStore.Notes.Cast<IRecord>()
                .Concat(_dataStore.BankCards.Cast<IRecord>())
                .ToList();
                Records = CollectionViewSource.GetDefaultView(allRecords);*/
                Records = CollectionViewSource.GetDefaultView(_dataStore.Notes.Cast<IRecord>().Concat(_dataStore.BankCards.Cast<IRecord>()).ToList());
                Records.Filter = RecordFilter;
                RaisePropertiesChanged(nameof(Records));
                FilterCategory = null;
                StandartCategory = _StandartCategories.ElementAt(0);
                _FilterText = string.Empty;
                SelectedRecord = null;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show($"Ошибка при вызове события удаления заметки.", "NoteEventError", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        private void noteUpdateAddEvent(Guid noteID)
        {
            try
            {
                /*List<IRecord> allRecords = _dataStore.Notes.Cast<IRecord>()
                .Concat(_dataStore.BankCards.Cast<IRecord>())
                .ToList();
                Records = CollectionViewSource.GetDefaultView(allRecords);*/
                Records = CollectionViewSource.GetDefaultView(_dataStore.Notes.Cast<IRecord>().Concat(_dataStore.BankCards.Cast<IRecord>()).ToList());
                Records.Filter = RecordFilter;
                RaisePropertiesChanged(nameof(_Records));

                RaisePropertiesChanged(nameof(Records));
                FilterCategory = null;
                StandartCategory = _StandartCategories.ElementAt(0);
                _FilterText = string.Empty;
                SelectedRecord = _dataStore.Notes.Single(x => x.noteID == noteID) as IRecord;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show($"Ошибка при вызове события добавления/изменения заметки.", "NoteEventError", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        private void bankCardUpdAddEvent(Guid bankCardID)
        {
            try
            {
                /*List<IRecord> allRecords = _dataStore.Notes.Cast<IRecord>()
                .Concat(_dataStore.BankCards.Cast<IRecord>())
                .ToList();
                Records = CollectionViewSource.GetDefaultView(allRecords);*/
                Records = CollectionViewSource.GetDefaultView(_dataStore.Notes.Cast<IRecord>().Concat(_dataStore.BankCards.Cast<IRecord>()).ToList());
                Records.Filter = RecordFilter;
                RaisePropertiesChanged(nameof(_Records));

                RaisePropertiesChanged(nameof(Records));
                FilterCategory = null;
                StandartCategory = _StandartCategories.ElementAt(0);
                _FilterText = string.Empty;
                SelectedRecord = _dataStore.BankCards.Single(x => x.cardID == bankCardID) as IRecord;
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show($"Ошибка при вызове события добавления/изменения заметки.", "NoteEventError", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private bool RecordFilter(object item)
        {
            IRecord record = item as IRecord;
            if (_FilterCategory != null)
            {
                if (record.CategoryID == _FilterCategory.categoryID)
                {
                    return record.Title.Contains(_FilterText);
                }
            }
            if (_StandartCategory != null)
            {
                if (_StandartCategory.categoryID == _StandartCategories[0].categoryID)
                {
                    return record.Title.Contains(_FilterText);
                }
                else if (record.CategoryID == _StandartCategory.categoryID)
                {
                    return record.Title.Contains(_FilterText);
                }
            }
            return false;
        }

        private void ShowRecord()
        {
            try
            {
                //throw new NotImplementedException("ManagerVM => ShowRecord => NotImplementException");
                if (SelectedRecord != null && SelectedRecord is IRecord)
                {
                    List<Category> senderCategoryModels = new List<Category>();
                    senderCategoryModels.AddRange(_StandartCategories);
                    senderCategoryModels.RemoveRange(0, 1);
                    senderCategoryModels.AddRange(_dataStore.Categories);
                    if (SelectedRecord is Note)
                    {
                        Note? item = SelectedRecord as Note;
                        ////NotImplemented
                        _viewerNavigator.selectedShowerPage = new ShowNoteVM(_viewerNavigator, _dataStore, item, senderCategoryModels); 
                    }
                    else if (SelectedRecord is BankCard) 
                    {
                        BankCard? item = SelectedRecord as BankCard;
                        ////NotImplemented
                        _viewerNavigator.selectedShowerPage = new ShowBankCardVM(_viewerNavigator, _dataStore, item, senderCategoryModels);
                    }
                }
                else if (SelectedRecord == null)
                {
                    _viewerNavigator.selectedShowerPage = null;
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show($"Ошибка при попытке отображения записи.", "ShowRecord_Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
