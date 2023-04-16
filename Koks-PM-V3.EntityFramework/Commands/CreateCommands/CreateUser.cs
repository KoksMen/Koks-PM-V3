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
    public class CreateUser : ICreateUser
    {
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public CreateUser(StorageDbContextFactory storageDbContextFactory)
        {
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async Task Execute(User user)
        {
            using (StorageDbContext context =  _storageDbContextFactory.Create())
            {
                UserDto userDto = new UserDto()
                {
                    UserDtoID = user.userID,
                    userAvatar = user.userAvatar,
                    userName = user.userName,
                    userLogin = user.userLogin,
                    userPassword = user.userPassword,
                    userTotpKey = user.userTotpKey,
                    userTelegramChatID = user.userTelegramChatID,
                    userTelegramBotApi = user.userTelegramBotApi,
                    userNotes = new List<NoteDto>(),
                    userBankCards = new List<BankCardDto>(),
                    userCategories = new List<CategoryDto>(),
                    createDate = user.createDate,
                    modifyDate = user.modifyDate,
                };

                context.Users.Add(userDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
