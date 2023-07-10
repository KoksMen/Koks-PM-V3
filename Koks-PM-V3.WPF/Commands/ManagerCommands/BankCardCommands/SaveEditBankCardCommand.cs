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
    public class SaveEditBankCardCommand : ICommand
    {
        private readonly ShowerPageNavigator _showerPageNavigator;
        private readonly DataStore _dataStore;
        private readonly string _nameBankCard;
        private readonly string _numberBankCard;
        private readonly string _holderBankCard;
        private readonly string _cvvBankCard;
        private readonly string _typeBankCard;
        private readonly string _expiryDateBankCard;
        private readonly Guid _categoryID;
        private readonly BankCard _bankCardModel;

        public SaveEditBankCardCommand(ShowerPageNavigator showerPageNavigator, DataStore dataStore, 
            string nameBankCard, string numberBankCard, 
            string holderBankCard, string cvvBankCard, 
            string typeBankCard, string expiryDateBankCard, 
            Guid categoryID, BankCard bankCardModel)
        {
            _showerPageNavigator = showerPageNavigator;
            _dataStore = dataStore;
            _nameBankCard = nameBankCard;
            _numberBankCard = numberBankCard;
            _holderBankCard = holderBankCard;
            _cvvBankCard = cvvBankCard;
            _typeBankCard = typeBankCard;
            _expiryDateBankCard = expiryDateBankCard;
            _categoryID = categoryID;
            _bankCardModel = bankCardModel;
        }
        /*
         * EliteBankCard
         * 4255123456789999
         * Nikita
         * 12/27
         * Visa
         * Избранное
         */



        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (_categoryID == new Guid("11111111-1111-1111-1111-111111111111") || _categoryID == Guid.Empty)
                return false;

            if (_nameBankCard.Length < 5 || _nameBankCard == string.Empty || _nameBankCard == null)
                return false;

            if (_numberBankCard.Length < 16 || _numberBankCard == string.Empty || _numberBankCard == null)
                return false;

            if (_holderBankCard.Length < 5 || _holderBankCard == string.Empty || _holderBankCard == null)
                return false;

            if (_cvvBankCard.Length != 3 || _cvvBankCard == string.Empty || _cvvBankCard == null)
                return false;

            if (_typeBankCard != "Visa" && _typeBankCard != "MasterCard" && _typeBankCard != "Maestro" && _typeBankCard != "Mir" && _typeBankCard != "Other")
                return false;


            if (_categoryID != _bankCardModel.CategoryID)
                return true;
            if (_nameBankCard != _bankCardModel.cardName)
                return true;
            if (_numberBankCard != _bankCardModel.cardNumber)
                return true;
            if (_holderBankCard != _bankCardModel.cardHolder)
                return true;
            if (_cvvBankCard != _bankCardModel.cardCVC)
                return true;
            if (_typeBankCard != _bankCardModel.cardType)
                return true;
            if (_expiryDateBankCard != _bankCardModel.cardExpiryDate.ToString("MM/yy"))
                return true;

            return false;
        }

        public void Execute(object? parameter)
        {
            try
            {
                MessageBox.Show("SaveEditBankCardCommand => CanExecute => expiry data check");

                BankCard updateBankCard = new BankCard(
                    _bankCardModel.cardID,
                    _nameBankCard,
                    _numberBankCard,
                    _holderBankCard,
                    _cvvBankCard,
                    _typeBankCard,
                    DateTime.ParseExact(_expiryDateBankCard, "MM/yy", null, System.Globalization.DateTimeStyles.None),
                    _categoryID,
                    _bankCardModel.userID,
                    DateTime.Now,
                    _bankCardModel.createDate
                    );

                _dataStore?.UpdateBankCard(updateBankCard);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
