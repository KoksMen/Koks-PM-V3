using Koks_PM_V3.Domain.Commands.CreateCommands;
using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Commands.CreateCommands
{
    public class CreateBankCard: ICreateBankCard
    {
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public CreateBankCard(StorageDbContextFactory storageDbContextFactory)
        {
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async Task Execute(BankCard bankCard)
        {
            using (StorageDbContext context = _storageDbContextFactory.Create())
            {
                BankCardDto bankCardDto = new BankCardDto()
                {
                    BankCardDtoID = bankCard.cardID,
                    cardName = bankCard.cardName,
                    cardNumber = bankCard.cardNumber,
                    cardCVC = bankCard.cardCVC,
                    cardExpiryDate = bankCard.cardExpiryDate,
                    cardHolder = bankCard.cardHolder,
                    cardType = bankCard.cardType,
                    categoryID = bankCard.categoryID,
                    createDate = bankCard.createDate,
                    modifyDate = bankCard.modifyDate,
                    userID = bankCard.userID,
                };

                context.BankCards.Add(bankCardDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
