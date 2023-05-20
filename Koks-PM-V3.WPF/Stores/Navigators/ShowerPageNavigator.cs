using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.Stores.Navigators
{
    public class ShowerPageNavigator : BindableBase
    {
		private BindableBase _selectedShowerPage;

		public BindableBase selectedShowerPage
		{
			get { return _selectedShowerPage; }
			set { _selectedShowerPage = value; ShowerPageChanged?.Invoke(); }
		}

		public event Action ShowerPageChanged;

	}
}
