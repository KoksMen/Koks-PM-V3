using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.Stores.DataStores
{
    public class TotpDataStore
    {
        private string _userTotpNumbers = string.Empty;

        public string UserTotpNumbers
        {
            get { return _userTotpNumbers; }
            set { _userTotpNumbers = value; }
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
