using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Koks_PM_V3.WPF.Stores.DataStores
{
    public class PasswordGeneratorDataStore : BindableBase
    {
		private string _generatedPassword = string.Empty;

		public string generatedPassword
		{
			get { return _generatedPassword; }
			set { _generatedPassword = value; RaisePropertiesChanged(nameof(generatedPassword)); passwordUpdated?.Invoke(); }
		}

		public event Action passwordUpdated;

	}
}
