using Koks_PM_V3.Domain.Commands.DeleteCommands;
using Koks_PM_V3.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Commands.DeleteCommands
{
    public class DeleteUser : IDeleteUser
    {
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public DeleteUser(StorageDbContextFactory storageDbContextFactory)
        {
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async Task Execute(Guid userID)
        {
            using (StorageDbContext context = _storageDbContextFactory.Create())
            {
                UserDto userDto = new UserDto()
                {
                    UserDtoID = userID,
                };

                context.Users.Remove(userDto);
                context.SaveChangesAsync();
            }
        }
    }
}
