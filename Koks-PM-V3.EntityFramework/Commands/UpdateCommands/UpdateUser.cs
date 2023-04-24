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
    public class UpdateUser : IUpdateUser
    {
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public UpdateUser(StorageDbContextFactory storageDbContextFactory)
        {
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async Task Execute(User user)
        {
            using (StorageDbContext context = _storageDbContextFactory.Create())
            {
                UserDto userDto = new UserDto()
                {
                    UserDtoID = user.userID,
                    userName = user.userName,
                    userLogin = user.userLogin,
                    userPassword = user.userPassword,
                    userTotpKey = user.userTotpKey,
                    userTelegramBotApi = user.userTelegramBotApi,
                    userTelegramChatID = user.userTelegramChatID,
                    userAvatar = user.userAvatar,
                    modifyDate = user.modifyDate,
                    createDate = user.createDate,
                    userNotes = GetNotes(user.userNotes),
                    userBankCards = GetBankCards(user.userBankCards),
                    userCategories = GetCategories(user.userCategories),
                };

                context.Users.Update(userDto);
                await context.SaveChangesAsync();
            }
        }

        private List<NoteDto> GetNotes(List<Note> notes)
        {
            var result = new List<NoteDto>();

            result = notes.Select(x => new NoteDto
            {
                NoteDtoID = x.noteID,
                noteName = x.noteName,
                noteLogin = x.noteLogin,
                notePassword = x.notePassword,
                noteUrl = x.noteUrl,
                noteTotp = x.noteTotp,
                userID = x.userID,
                categoryID = x.categoryID,
                modifyDate = x.modifyDate,
                createDate = x.createDate,
            }).ToList();

            return result;
        }
        private List<BankCardDto> GetBankCards(List<BankCard> bankCards)
        {
            var result = new List<BankCardDto>();

            result = bankCards.Select(x => new BankCardDto
            {
                BankCardDtoID = x.cardID,
                cardName = x.cardName,
                cardNumber = x.cardNumber,
                cardHolder = x.cardHolder,
                cardCVC = x.cardCVC,
                cardType = x.cardType,
                cardExpiryDate = x.cardExpiryDate,
                userID = x.userID,
                categoryID = x.categoryID,
                modifyDate = x.modifyDate,
                createDate = x.createDate,
            }
            ).ToList();

            return result;
        }
        private List<CategoryDto> GetCategories(List<Category> categories)
        {
            var result = new List<CategoryDto>();

            result = categories.Select(x => new CategoryDto
            {
                CategoryDtoID = x.categoryID,
                categoryName = x.categoryName,
                userID = x.userID,
                modifyDate= x.modifyDate,
                createDate = x.createDate,
            }).ToList();

            return result;
        }

    }
}
