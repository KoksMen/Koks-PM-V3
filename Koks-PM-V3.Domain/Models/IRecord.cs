using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.Domain.Models
{
    public interface IRecord
    {
        public Guid ID { get; }
        public string Title { get; }
        public string Desctiption { get; }
    }
}
