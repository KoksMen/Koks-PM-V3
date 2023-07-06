using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.EntityFramework.DTOs;

namespace Koks_PM_V3.WPF.Services
{
    public static class SymmetricEncryptorModule
    {
        private static string EncryptString(string toEncrypt, string password)
        {
            var key = GetKey(password);

            using (var aes = Aes.Create())
            using (var encryptor = aes.CreateEncryptor(key, key))
            {
                var plainText = Encoding.UTF8.GetBytes(toEncrypt);
                byte[] encryptedresult = encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
                return Convert.ToBase64String(encryptedresult);
            }
        }

        private static string DecryptToString(string encryptedData, string password)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
            var key = GetKey(password);

            using (var aes = Aes.Create())
            using (var encryptor = aes.CreateDecryptor(key, key))
            {
                var decryptedBytes = encryptor
                    .TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        private static byte[] GetKey(string password)
        {
            var keyBytes = Encoding.UTF8.GetBytes(password);
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(keyBytes);
            }
        }

        public static Note EncryptNote(Note note, string password)
        {
            Note EnctyptedNote = new Note(
                note.noteID,
                EncryptString(note.noteName, password),
                EncryptString(note.noteLogin, password),
                EncryptString(note.notePassword, password),
                EncryptString(note.noteUrl, password),
                EncryptString(note.noteTotp, password),
                note.categoryID,
                note.userID,
                note.createDate,
                note.modifyDate
                );
            return EnctyptedNote;
        }
        public static Note DecryptNote(Note note, string password)
        {
            Note DecryptedNote = new Note(
                note.noteID,
                DecryptToString(note.noteName, password),
                DecryptToString(note.noteLogin, password),
                DecryptToString(note.notePassword, password),
                DecryptToString(note.noteUrl, password),
                DecryptToString(note.noteTotp, password),
                note.categoryID,
                note.userID,
                note.createDate,
                note.modifyDate
                );
            return DecryptedNote;
        }
        public static BankCard EncryptBankCard(BankCard bankCard, string password)
        {
            BankCard EnctyptedNote = new BankCard(
                bankCard.cardID,
                EncryptString(bankCard.cardName, password),
                EncryptString(bankCard.cardNumber, password),
                EncryptString(bankCard.cardHolder, password),
                EncryptString(bankCard.cardCVC, password),
                EncryptString(bankCard.cardType, password),
                bankCard.cardExpiryDate,
                bankCard.categoryID,
                bankCard.userID,
                bankCard.modifyDate,
                bankCard.createDate
                );
            return EnctyptedNote;
        }
        public static BankCard DecryptBankCard(BankCard bankCard, string password)
        {
            BankCard DecryptedBankCard = new BankCard(
                bankCard.cardID,
                DecryptToString(bankCard.cardName, password),
                DecryptToString(bankCard.cardNumber, password),
                DecryptToString(bankCard.cardHolder, password),
                DecryptToString(bankCard.cardCVC, password),
                DecryptToString(bankCard.cardType, password),
                bankCard.cardExpiryDate,
                bankCard.categoryID,
                bankCard.userID,
                bankCard.modifyDate,
                bankCard.createDate
                );
            return DecryptedBankCard;
        }
        public static Category EncryptCategory(Category category, string password)
        {
            Category EnctyptedCategory = new Category(
                category.categoryID,
                EncryptString(category.categoryName, password),
                category.userID,
                category.modifyDate,
                category.createDate
                );
            return EnctyptedCategory;
        }
        public static Category DecryptCategory(Category category, string password)
        {
            Category DecryptedCategory = new Category(
                category.categoryID,
                DecryptToString(category.categoryName, password),
                category.userID,
                category.modifyDate,
                category.createDate
                );
            return DecryptedCategory;
        }
    }
}
