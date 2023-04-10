using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.DTOs
{
    public class CategoryDto
    {
        [Key]
        [Required]
        public Guid CategoryDtoID { get; set; }
        [Required]
        public string categoryName { get; set; }
        [Required]
        public Guid userID { get; set; }
        [Required]
        public DateTime modifyDate { get; set; }
        [Required]
        public DateTime createDate { get; set; }
        public virtual UserDto User { get; set; }

    }
}
