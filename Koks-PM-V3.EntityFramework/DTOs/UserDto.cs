using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.DTOs
{
    public class UserDto
    {
        [Key]
        [Required] 
        public Guid UserDtoID { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string userLogin { get; set; }
        [Required]
        public string userPassword { get; set; }
        public string? userTotpKey { get; set; }
        public string? userTelegramBotApi { get; set; }
        public string? userTelegramChatID { get; set; }
        public byte[]? userAvatar { get; set; }
        [Required]
        public DateTime modifyDate { get; set; }
        [Required]
        public DateTime createDate { get; set; }
        [Required]
        public virtual List<NoteDto> userNotes { get; set; }
        [Required]
        public virtual List<BankCardDto> userBankCards { get; set; }
        [Required]
        public virtual List<CategoryDto> userCategories { get; set; }
    }
}
