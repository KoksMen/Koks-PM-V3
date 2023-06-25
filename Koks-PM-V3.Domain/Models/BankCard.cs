using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.Domain.Models
{
    public class BankCard
    {
        public BankCard(Guid cardID, string cardName, 
            string cardNumber, string cardHolder, 
            string cardCVC, string cardType, 
            DateTime cardExpiryDate, Guid categoryID, 
            Guid userID, DateTime modifyDate, DateTime createDate)
        {
            this.cardID = cardID;
            this.cardName = cardName;
            this.cardNumber = cardNumber;
            this.cardHolder = cardHolder;
            this.cardCVC = cardCVC;
            this.cardType = cardType;
            this.cardExpiryDate = cardExpiryDate;
            this.categoryID = categoryID;
            this.userID = userID;
            this.modifyDate = modifyDate;
            this.createDate = createDate;
        }

        public Guid ID => cardID;
        public Guid CategoryID => categoryID;
        public Guid UserID => userID;
        public string Title => cardName;
        public string Desctiption => cardNumber;

        public Guid cardID { get; set; }
        public string cardName { get; set; }
        public string cardNumber { get; set; }
        public string cardHolder { get; set; }
        public string cardCVC { get; set; }
        public string cardType { get; set; }
        public DateTime cardExpiryDate { get; set; }
        public Guid categoryID { get; set; }
        public Guid userID { get; set; }
        public DateTime modifyDate { get; set; }
        public DateTime createDate { get; set; }
    }
}
