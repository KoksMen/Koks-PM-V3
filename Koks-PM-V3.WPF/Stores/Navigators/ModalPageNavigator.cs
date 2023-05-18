using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.Stores.Navigators
{
    public class ModalPageNavigator : BindableBase
    {
        private BindableBase _selectedModalPage;
        public BindableBase SelectedModalPage
        {
            get { return _selectedModalPage; }
            set { _selectedModalPage = value; ModalPageChanged?.Invoke();  }
        }

        public event Action ModalPageChanged;
    }
}
