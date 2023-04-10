using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.DTOs
{
    public class NoteDto
    {
        [Key]
        [Required]
        public Guid NoteDtoID { get; set; }
        [Required]
        public string noteName { get; set; }
        [Required]
        public string noteLogin { get; set; }
        [Required]
        public string notePassword { get; set; }
        public string noteUrl { get; set; }
        public string noteTotp { get; set; }
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
