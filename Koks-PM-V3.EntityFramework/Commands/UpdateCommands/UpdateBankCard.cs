using Koks_PM_V3.Domain.Commands.UpdateCommands;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Commands.UpdateCommands
{
    public class UpdateBankCard : IUpdateBankCard
    {
        private readonly StorageDbContextFactory _storageContextFactory;

        public UpdateBankCard(StorageDbContextFactory storageContextFactory)
        {
            _storageContextFactory = storageContextFactory;
        }

        public async Task Execute(BankCard bankCard)
        {
            using (StorageDbContext context = _storageContextFactory.Create())
            {
                BankCardDto bankCardDto = new BankCardDto()
                {
                    BankCardDtoID = bankCard.cardID,
                    cardName = bankCard.cardName,
                    cardHolder = bankCard.cardHolder,
                    cardCVC = bankCard.cardCVC,
                    cardType = bankCard.cardType,
                    cardExpiryDate = bankCard.cardExpiryDate,
                    categoryID = bankCard.categoryID,
                    userID = bankCard.userID,
                    modifyDate = bankCard.modifyDate,
                    createDate = bankCard.createDate,
                };

                context.BankCards.Update(bankCardDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
