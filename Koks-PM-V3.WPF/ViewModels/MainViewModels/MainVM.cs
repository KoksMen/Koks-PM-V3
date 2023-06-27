using DevExpress.Mvvm;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.ViewModels.MainViewModels
{
    public class MainVM : BindableBase
    {
        private readonly MainPageNavigator _pageNavigator;
        private readonly DataStoreFactory _dataStoreFactory;
        public BindableBase Selectedpage => _pageNavigator.SelectedMainPage;

        public MainVM(MainPageNavigator pageNavigator, DataStoreFactory dataStoreFactory)
        {
            _dataStoreFactory = dataStoreFactory;

            _pageNavigator = pageNavigator;
            _pageNavigator.MainPageChanged += _pageNavigator_MainPageChanged;
            _pageNavigator.SelectedMainPage = new LoginVM(_pageNavigator, _dataStoreFactory);

        }

        private void _pageNavigator_MainPageChanged()
        {
            RaisePropertiesChanged(nameof(Selectedpage));
        }
    }
}
