using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Koks_PM_V3.WPF.Commands.ManagerCommands.BankCardCommands
{
    public class SaveAddBankCardCommand : ICommand
    {
        private readonly ShowerPageNavigator _showerNavigator;
        private readonly DataStore _dataStore;
        private readonly Guid _categoryID;
        private readonly string _nameBankCard;
        private readonly string _numberBankCard;
        private readonly string _cvvBankCard;
        private readonly string _holderBankCard;
        private readonly string _typeBankCard;
        private readonly DateTime _expiryDateBankCard;

        public SaveAddBankCardCommand(ShowerPageNavigator showerNavigator, DataStore dataStore, Guid categoryID, 
            string nameBankCard, string numberBankCard, string cvvBankCard, 
            string holderBankCard, string typeBankCard, DateTime expiryDateBankCard)
        {
            _showerNavigator = showerNavigator;
            _dataStore = dataStore;
            _categoryID = categoryID;
            _nameBankCard = nameBankCard;
            _numberBankCard = numberBankCard;
            _cvvBankCard = cvvBankCard;
            _holderBankCard = holderBankCard;
            _typeBankCard = typeBankCard;
            _expiryDateBankCard = expiryDateBankCard;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            MessageBox.Show("SaveBankCardCommand => CanExecure => no check param/function");
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                BankCard addBankCard = new BankCard(
                    Guid.NewGuid(),
                    _nameBankCard,
                    _numberBankCard,
                    _holderBankCard,
                    _cvvBankCard,
                    _typeBankCard,
                    _expiryDateBankCard,
                    _categoryID,
                    _dataStore.UserAccount.userID,
                    DateTime.Now,
                    DateTime.Now);

                _dataStore?.AddBankCard(addBankCard);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
