﻿using DevExpress.Mvvm;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Commands;
using Koks_PM_V3.WPF.Commands.OpenPageCommands.OpenBankCardPageCommands;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.ViewModels.ManagerViewModels
{
    public class ShowBankCardVM : BindableBase
    {
        private ModalPageNavigator _modalPageNaviagator;
        private readonly ShowerPageNavigator _viewerNavigator;
        private readonly DataStore _dataStore;
        private readonly BankCard _bankCard;
        private readonly List<Category> _categories;

        public ShowBankCardVM(ModalPageNavigator modalPageNavigator, ShowerPageNavigator viewerNavigator, DataStore dataStore, BankCard bankCard, List<Category> senderCategories)
        {
            try
            {
                _modalPageNaviagator = modalPageNavigator;
                _viewerNavigator = viewerNavigator;
                _dataStore = dataStore;
                _bankCard = bankCard;
                _SelectedCategory = new List<Category>
                {
                    senderCategories.First(x => x.categoryID == _bankCard.CategoryID)
                };
                _categories = senderCategories;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        private string _Name => _bankCard.cardName;

        public string Name
        {
            get { return _Name; }
        }
        private string _Number => _bankCard.cardNumber;

        public string Number
        {
            get { return _Number; }
        }
        private string _CVV => _bankCard.cardCVC;

        public string CVV
        {
            get { return _CVV; }
        }

        private string[] cardTypes = { "Visa", "MasterCard", "MIR", "UnionPay", "Maestro", "Belkart", "American Express", "Other" };
        public string[] CardTypes
        {
            get { return cardTypes; }
            set { cardTypes = value; }
        }

        private string _Type => _bankCard.cardType;

        public string Type
        {
            get { return _Type; }
        }

        private string _Holder => _bankCard.cardHolder;

        public string Holder
        {
            get { return _Holder; }
        }

        private string _ExpiryDate => _bankCard.cardExpiryDate.ToString("MM/yy", new CultureInfo("en-US"));

        public string ExpiryDate
        {
            get { return _ExpiryDate; }
        }

        public string modifyDate => _bankCard.modifyDate.ToString("G");
        public string createDate => _bankCard.createDate.ToString("G");

        private List<Category> _SelectedCategory;
        public List<Category> SelectedCategory
        {
            get { return _SelectedCategory; }
        }

        public ICommand EditCommand => new OpenEditBankCardPageCommand(_modalPageNaviagator, _viewerNavigator, _dataStore, _categories, _bankCard);
        public ICommand CopyName => new RelayCommand(parameter =>
        {
            Clipboard.SetText(Name);
        });
        public ICommand CopyLogin => new RelayCommand(parameter =>
        {
            Clipboard.SetText(Number);
        });
        public ICommand CopyPassword => new RelayCommand(parameter =>
        {
            Clipboard.SetText(CVV);
        });
        public ICommand CopyType => new RelayCommand(parameter =>
        {
            Clipboard.SetText(Type);
        });
        public ICommand CopyHolder => new RelayCommand(parameter =>
        {
            Clipboard.SetText(Holder);
        });
        public ICommand CopyDate => new RelayCommand(parameter =>
        {
            Clipboard.SetText(ExpiryDate);
        });

    }
}
