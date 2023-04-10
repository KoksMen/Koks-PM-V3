using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.Domain.Models
{
    public class User
    {
        public User(Guid userID, string userName, string userLogin, 
            string userPassword, string userTotpKey, string userTelegramBotApi, 
            string userTelegramChatID, byte[] userAvatar, DateTime modifyDate,
            DateTime createDate, List<Note> userNotes, 
            List<BankCard> userBankCards, List<Category> userCategories)
        {
            this.userID = userID;
            this.userName = userName;
            this.userLogin = userLogin;
            this.userPassword = userPassword;
            this.userTotpKey = userTotpKey;
            this.userTelegramBotApi = userTelegramBotApi;
            this.userTelegramChatID = userTelegramChatID;
            this.userAvatar = userAvatar;
            this.modifyDate = modifyDate;
            this.createDate = createDate;
            this.userNotes = userNotes;
            this.userBankCards = userBankCards;
            this.userCategories = userCategories;
        }

        public Guid userID { get; set; }
        public string userName { get; set; }
        public string userLogin { get; set; }
        public string userPassword { get; set; }
        public string userTotpKey { get; set; }
        public string userTelegramBotApi { get; set; }
        public string userTelegramChatID { get; set; }
        public byte[] userAvatar { get; set; }
        public DateTime modifyDate { get; set; }
        public DateTime createDate { get; set; }
        public List<Note> userNotes { get; set; }
        public List<BankCard> userBankCards { get; set; }
        public List<Category> userCategories { get; set; }
    }
}
