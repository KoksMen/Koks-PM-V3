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
                    //list note
                    //list bank card
                    // list category
                };

                context.Users.Update(userDto);
                await context.SaveChangesAsync();
            }
        }

    }
}
