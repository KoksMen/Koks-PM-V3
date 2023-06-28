using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.DTOs
{
    public class BankCardDto
    {
        [Key]
        [Required]
        public Guid BankCardDtoID { get; set; }
        [Required]
        public string cardName { get; set; }
        [Required]
        public string cardNumber { get; set; }
        [Required]
        public string? cardHolder { get; set; }
        [Required]
        public string cardCVC { get; set; }
        [Required]
        public string? cardType { get; set; }
        [Required]
        public DateTime cardExpiryDate { get; set; }
        [Required]
        public Guid categoryID { get; set; }
        [Required]
        public Guid userID { get; set; }
        [Required]
        public DateTime modifyDate { get; set; }
        [Required]
        public DateTime createDate { get; set; }
        public virtual UserDto User { get; set; }

    }
}
