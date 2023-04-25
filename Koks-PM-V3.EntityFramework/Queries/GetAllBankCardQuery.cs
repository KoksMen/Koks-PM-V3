using Koks_PM_V3.Domain.Models;
using Koks_PM_V3.Domain.Querires;
using Koks_PM_V3.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Queries
{
    public class GetAllBankCardQuery : IGetAllBankCards
    {
        private readonly StorageDbContextFactory _storageContextFactory;

        public GetAllBankCardQuery(StorageDbContextFactory storageContextFactory)
        {
            _storageContextFactory = storageContextFactory;
        }

        public async Task<List<BankCard>> Execute(Guid userID)
        {
            using (StorageDbContext context  = _storageContextFactory.Create())
            {
                List<BankCardDto> bankCardDtos = await context.BankCards.ToListAsync();

                List<BankCard> bankCards = bankCardDtos.Select(x => new BankCard(
                    x.BankCardDtoID,
                    x.cardName,
                    x.cardNumber,
                    x.cardHolder,
                    x.cardCVC,
                    x.cardType,
                    x.cardExpiryDate,
                    x.categoryID,
                    x.userID,
                    x.modifyDate,
                    x.createDate
                    )).ToList();

                return bankCards;

            }
        }
    }
}
