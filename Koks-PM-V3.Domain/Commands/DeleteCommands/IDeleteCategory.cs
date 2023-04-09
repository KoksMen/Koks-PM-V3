using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.Domain.Commands.DeleteCommands
{
    public interface IDeleteCategory
    {
        Task Execute(Guid categoryID);
    }
}
