using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.EntityFramework;
using Koks_PM_V3.EntityFramework.DTOs;
using Koks_PM_V3.WPF.Commands.MainCommands;
using Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenMainPageCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.MainViewModels
{
    public class TotpVM : BindableBase
    {
        private readonly MainPageNavigator _pageNavigator;
        private readonly DataStoreFactory _dataStoreFactory;
        private readonly StorageDbContextFactory _storageDbContextFactory;
        private readonly UserDto authorizedUser;

        public TotpVM(MainPageNavigator pageNavigator, DataStoreFactory dataStoreFactory, StorageDbContextFactory storageDbContextFactory, UserDto user)
        {
            _pageNavigator = pageNavigator;
            _dataStoreFactory = dataStoreFactory;
            _storageDbContextFactory = storageDbContextFactory;
            authorizedUser = user;
        }

        private string _Numbers = string.Empty;

        public string Numbers
        {
            get { return _Numbers; }
            set
            {
                _Numbers = value;
                RaisePropertiesChanged(nameof(Numbers));
                RaisePropertiesChanged(nameof(ConfirmTotpCommand));
            }
        }

        public ICommand ConfirmTotpCommand => new TotpCommand(_pageNavigator, _Numbers, _dataStoreFactory, authorizedUser);

        private ICommand backLoginCommand => new OpenLoginCommand(_pageNavigator, _dataStoreFactory, _storageDbContextFactory);


        public ICommand BackLoginCommand
        {
            get { return backLoginCommand; }
        }
    }
}
