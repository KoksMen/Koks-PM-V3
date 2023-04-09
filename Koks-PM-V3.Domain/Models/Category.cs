using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.Domain.Models
{
    public class Category
    {
        public Guid categoryID { get; set; }
        public string categoryName { get; set; }
        public Guid userID { get; set; }
        public DateTime modifyDate { get; set; }
        public DateTime createDate { get; set; }
    }
}
