using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.Stores.DataStores
{
    public class LoginDataStore
    {
		private string _login;

		public string Login
		{
			get { return _login; }
			set { _login = value; }
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		//Maybe chang
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
