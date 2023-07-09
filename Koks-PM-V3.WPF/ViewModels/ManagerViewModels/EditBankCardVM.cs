using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Commands.ClosePageCommands;
using Koks_PM_V3.WPF.Commands.ManagerCommands.BankCardCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.ManagerViewModels
{
    public class EditBankCardVM : BindableBase
    {
        private readonly ShowerPageNavigator _showerPageNavigator;
        private readonly DataStore _dataStore;
        private readonly List<Category> _categories;
        private readonly BankCard _bankCard;

        public EditBankCardVM(ShowerPageNavigator viewerNavigator, DataStore dataStore, List<Category> senderCategories, BankCard bankCard)
        {
            _showerPageNavigator = viewerNavigator;
            _dataStore = dataStore;
            _categories = senderCategories;
            _bankCard = bankCard;
            Name = _bankCard.cardName;
            Number = _bankCard.cardName;
            CVV = _bankCard.cardCVC;
            Type = _bankCard.cardType;
            Holder = _bankCard.cardHolder;
            ExpiryDate = _bankCard.cardExpiryDate.ToString("dd.MM.yyyy");
            SelectedCategory = _categories.First(x => x.categoryID == _bankCard.CategoryID);
        }

        private string _Name = string.Empty;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertiesChanged(nameof(Name)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }
        private string _Number = string.Empty;

        public string Number
        {
            get { return _Number; }
            set { _Number = value; RaisePropertiesChanged(nameof(Number)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }
        private string _CVV = string.Empty;

        public string CVV
        {
            get { return _CVV; }
            set { _CVV = value; RaisePropertiesChanged(nameof(CVV)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }
        private Category _Category = new Category(Guid.Empty, "Null", Guid.Empty, DateTime.Now, DateTime.Now);

        public Category SelectedCategory
        {
            get { return _Category; }
            set { _Category = value; RaisePropertiesChanged(nameof(SelectedCategory)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }

        private string _Type = string.Empty;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; RaisePropertiesChanged(nameof(Type)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }

        private string _Holder = string.Empty;

        public string Holder
        {
            get { return _Holder; }
            set { _Holder = value; RaisePropertiesChanged(nameof(Holder)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }

        private string _ExpiryDate = string.Empty;

        public string ExpiryDate
        {
            get { return _ExpiryDate; }
            set { _ExpiryDate = value; RaisePropertiesChanged(nameof(ExpiryDate)); RaisePropertiesChanged(nameof(SaveEditCommand)); }
        }


        public ICollection<Category> Categories => _categories;

        public ICommand SaveEditCommand => throw new NotImplementedException("EditBankCardVM - SaveAddCommand - NotImplementException");
        public ICommand CancelCommand => new CloseShowerPageCommand(_showerPageNavigator, _bankCard, _dataStore, _categories);
        public ICommand DeleteCommand => new DeleteBankCardCommand(_showerPageNavigator, _dataStore, _bankCard);
    }
}
