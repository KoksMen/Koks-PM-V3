using Koks_PM_V3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.Domain.Commands.UpdateCommands
{
    public interface IUpdateBankCard
    {
        Task Execute(BankCard bankCard);
    }
}
