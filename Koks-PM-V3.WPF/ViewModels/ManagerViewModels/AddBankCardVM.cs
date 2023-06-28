﻿using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
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
    public class AddBankCardVM : BindableBase
    {
        private readonly ShowerPageNavigator _viewerNavigator;
        private readonly DataStore _dataStore;
        private readonly List<Category> _categories;

        public AddBankCardVM(ShowerPageNavigator viewerNavigator, DataStore dataStore, List<Category> senderCategories)
        {
            _viewerNavigator = viewerNavigator;
            _dataStore = dataStore;
            _categories = senderCategories;
        }

        private string _Name = string.Empty;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertiesChanged(nameof(Name)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }
        private string _Number = string.Empty;

        public string Number
        {
            get { return _Number; }
            set { _Number = value; RaisePropertiesChanged(nameof(Number)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }
        private string _CVV = string.Empty;

        public string CVV
        {
            get { return _CVV; }
            set { _CVV = value; RaisePropertiesChanged(nameof(CVV)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }
        private Category _Category = new Category(Guid.Empty, "Null", Guid.Empty, DateTime.Now, DateTime.Now);

        public Category SelectedCategory
        {
            get { return _Category; }
            set { _Category = value; RaisePropertiesChanged(nameof(SelectedCategory)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }

        private string _Type = string.Empty;

        public string Type
        {
            get { return _Type; }
            set { _Type = value; RaisePropertiesChanged(nameof(Type)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }

        private string _Holder = string.Empty;

        public string Holder
        {
            get { return _Holder; }
            set { _Holder = value; RaisePropertiesChanged(nameof(Holder)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }
        
        private string _ExpiryDate = string.Empty;

        public string ExpiryDate
        {
            get { return _ExpiryDate; }
            set { _ExpiryDate = value; RaisePropertiesChanged(nameof(ExpiryDate)); RaisePropertiesChanged(nameof(SaveAddCommand)); }
        }

        public ICollection<Category> Categories => _categories;

        public ICommand SaveAddCommand => throw new NotImplementedException("AddBankCardVM - SaveAddCommand - NotImplementException");
        public ICommand CancelCommand => throw new NotImplementedException("AddBankCardVM - CancelCommand - NotImplementException");
    }
}