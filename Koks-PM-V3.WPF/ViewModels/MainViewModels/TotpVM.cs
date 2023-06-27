using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
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
        private readonly TotpDataStore _totpPageDataStore;
        private readonly DataStoreFactory _dataStoreFactory;
        private readonly User authorizedUser;

        public TotpVM(MainPageNavigator pageNavigator, DataStoreFactory dataStoreFactory, User user)
        {
            _pageNavigator = pageNavigator;
            _totpPageDataStore = new TotpDataStore();
            _dataStoreFactory = dataStoreFactory;
            _totpPageDataStore.DataStoreFactory = _dataStoreFactory;
            authorizedUser = user;
        }

        private string _Numbers;

        public string Numbers
        {
            get { return _Numbers; }
            set { _Numbers = value; _totpPageDataStore.UserTotpNumbers = value; RaisePropertiesChanged(nameof(AuthorizeCommand)); }
        }

        private ICommand _authorizeCommand => throw new NotImplementedException("RegisterVM => AuthorizeCommand => NotImplementedException");
        public ICommand AuthorizeCommand
        {
            get { return _authorizeCommand; }
        }

        private ICommand backLoginCommand => throw new NotImplementedException("RegisterVM => BackLoginCommand => NotImplementedException");


        public ICommand BackLoginCommand
        {
            get { return backLoginCommand; }
        }
    }
}
