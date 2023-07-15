using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.WPF.Stores.DataStores;
using Koks_PM_V3.WPF.Stores.Navigators;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly string _expiryDateBankCard;
        private DateTime parsedDate;

        public SaveAddBankCardCommand(ShowerPageNavigator showerNavigator, DataStore dataStore, Guid categoryID, 
            string nameBankCard, string numberBankCard, string cvvBankCard, 
            string holderBankCard, string typeBankCard, string expiryDateBankCard)
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

            if (_categoryID == new Guid("11111111-1111-1111-1111-111111111111") || _categoryID == Guid.Empty) {
                return false;
            }
            if (_nameBankCard.IsNullOrEmpty() || _nameBankCard.Length < 5) {
                return false;
            }
            if (IsInvalidCreditCardNumber(_numberBankCard)) {
                return false;
            }
            if (_holderBankCard.IsNullOrEmpty() || _holderBankCard.Length < 5) {
                return false;
            }
            if (_cvvBankCard.IsNullOrEmpty() || _cvvBankCard.Length != 3) {
                return false;
            }
            if (IsInvalidDateFormat(_expiryDateBankCard.ToString())) {
                return false;
            }
            if (IsInvalidCardType(_typeBankCard)) {
                return false;
            }
            
            return true;
        }

        private bool IsInvalidCreditCardNumber(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "");

            if (!cardNumber.All(char.IsDigit)) {
                return true;
            }

            if (cardNumber.Length < 13 || cardNumber.Length > 19) {
                return true;
            }

            return false;
            //Эта проверка вероятно излишня
            // Проверка, используя алгоритм Луна
            /*int sum = 0;
            bool isAlternateDigit = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--) 
            {
                int digit = int.Parse(cardNumber[i].ToString());

                if (isAlternateDigit) {
                    digit *= 2;
                    if (digit > 9) {
                        digit = digit % 10 + 1;
                    }
                }

                sum += digit;
                isAlternateDigit = !isAlternateDigit;
            }

            return sum % 10 != 0;*/
        }
        private bool IsInvalidDateFormat(string date)
        {
            return !DateTime.TryParseExact(date, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
        }
        private bool IsInvalidCardType(string type) {
            string[] cardTypes = { "Visa", "MasterCard", "MIR", "UnionPay", "Maestro", "Belkart", "American Express", "Other" };

            foreach (string cardType in cardTypes)
            {
                if (type.Equals(cardType, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }


        public void Execute(object? parameter)
        {
            try
            {
                BankCard addBankCard = new BankCard(
                    cardID: Guid.NewGuid(),
                    cardName: _nameBankCard,
                    cardNumber: _numberBankCard,
                    cardHolder: _holderBankCard,
                    cardCVC: _cvvBankCard,
                    cardType: _typeBankCard,
                    cardExpiryDate: parsedDate,
                    categoryID: _categoryID,
                    userID: _dataStore.UserAccount.userID,
                    modifyDate: DateTime.Now,
                    createDate: DateTime.Now);

                _dataStore?.AddBankCard(addBankCard);
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
