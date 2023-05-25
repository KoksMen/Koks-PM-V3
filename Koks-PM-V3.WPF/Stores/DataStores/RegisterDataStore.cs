using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.Stores.DataStores
{
    public class RegisterDataStore
    {
		private string _name = string.Empty;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _login = string.Empty;

		public string Login
		{
			get { return _login; }
			set { _login = value; }
		}

		private string _password = string.Empty;

		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		private string _confirmPassword = string.Empty;

		public string ConfirmPassword
		{
			get { return _confirmPassword; }
			set { _confirmPassword = value; }
		}

		private DataStoreFactory _dataStoreFactory;

		public DataStoreFactory DataStoreFactory
		{
			get { return _dataStoreFactory; }
			set 
			{ 
				if (_dataStoreFactory == null)
                    _dataStoreFactory = value;
            }
		}


	}
}
