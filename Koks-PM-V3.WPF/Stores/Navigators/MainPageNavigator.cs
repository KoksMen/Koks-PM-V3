using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.Stores.Navigators
{
    public class MainPageNavigator: BindableBase
    {
        private BindableBase _selectedMainPage;
        public BindableBase SelectedMainPage
        {
            get { return _selectedMainPage; }
            set { _selectedMainPage = value; MainPageChanged?.Invoke(); }
        }

        public event Action MainPageChanged;
    }
}
