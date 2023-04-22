using Koks_PM_V3.Domain.Commands.DeleteCommands;
using Koks_PM_V3.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Commands.DeleteCommands
{
    public class DeleteBankCard : IDeleteBankCard
    {
        private readonly StorageDbContextFactory _storageContextFactory;

        public DeleteBankCard(StorageDbContextFactory storageContextFactory)
        {
            _storageContextFactory = storageContextFactory;
        }

        public async Task Execute(Guid bankCardID)
        {
            using (StorageDbContext context = _storageContextFactory.Create())
            {
                BankCardDto bankCardDto = new BankCardDto()
                {
                    BankCardDtoID = bankCardID,
                };

                context.BankCards.Remove(bankCardDto);
                context.SaveChangesAsync();
            }
        }
    }
}
