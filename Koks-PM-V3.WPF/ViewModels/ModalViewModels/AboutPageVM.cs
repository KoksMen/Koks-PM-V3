using DevExpress.Mvvm;
using Koks_PM_V3.WPF.Stores.Navigators;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.ModalViewModels
{
    public class AboutPageVM : BindableBase
    {
        private readonly ModalPageNavigator _modalPageNavigator;

        public AboutPageVM(ModalPageNavigator modalPageNavigator)
        {
            _modalPageNavigator = modalPageNavigator;
        }

        public ICommand CloseCommand => throw new NotImplementedException("AboutPageVM - CloseCommand - NotImplementException");
    }
}
