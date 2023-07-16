using Koks_PM_V3.WPF.Stores.DataStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.WPF.Services
{
    public class PasswordGeneratorService
    {
        private const string UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";
        private const string SpecialLetters = "!@#$%^&*";

        private int passwordLength;
        private bool isHaveUpperLetters;
        private bool isHaveLowerLetters;
        private bool isHaveDigits;
        private bool isHaveSpecialLetters;

        public PasswordGeneratorService( int passwordLength, bool isHaveUpperLetters, bool isHaveLowerLetters, bool isHaveDigits, bool isHaveSpecialLetters)
        {
            this.passwordLength = passwordLength;
            this.isHaveUpperLetters = isHaveUpperLetters;
            this.isHaveLowerLetters = isHaveLowerLetters;
            this.isHaveDigits = isHaveDigits;
            this.isHaveSpecialLetters = isHaveSpecialLetters;
        }

        public string Generate() 
        {
            string allowedChars = string.Empty;
            if (isHaveUpperLetters) {
                allowedChars += UpperLetters;
            }
            if (isHaveLowerLetters) {
                allowedChars += LowerLetters;
            }
            if (isHaveDigits) {
                allowedChars += Digits;
            }
            if (isHaveSpecialLetters) {
                allowedChars += SpecialLetters;
            }

            if (string.IsNullOrEmpty(allowedChars))
                throw new ArgumentException("At least one character type must be selected.");

            Random rnd = new Random();
            //Генерация пароля
            var generatedPassword = new char[passwordLength];
            for (int i = 0; i < passwordLength; i++)
            {
                generatedPassword[i] = allowedChars[rnd.Next(0, allowedChars.Length)];
            }

            // Перемешивание символов пароля
            for (int i = 0; i < passwordLength - 1; i++)
            {
                int randomIndex = rnd.Next(i, passwordLength);
                char temp = generatedPassword[i];
                generatedPassword[i] = generatedPassword[randomIndex];
                generatedPassword[randomIndex] = temp;
            };

            return new string(generatedPassword);
        }
    }
}
