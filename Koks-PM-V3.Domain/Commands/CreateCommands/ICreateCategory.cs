using Koks_PM_V3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.Domain.Commands.CreateCommands
{
    public interface ICreateCategory
    {
        Task Execute(Category category);
    }
}
