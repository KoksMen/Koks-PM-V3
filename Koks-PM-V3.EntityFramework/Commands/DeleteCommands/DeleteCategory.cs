using Koks_PM_V3.Domain.Commands.DeleteCommands;
using Koks_PM_V3.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.EntityFramework.Commands.DeleteCommands
{
    public class DeleteCategory : IDeleteCategory
    {
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public DeleteCategory(StorageDbContextFactory storageDbContextFactory)
        {
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async Task Execute(Guid categoryID)
        {
            using (StorageDbContext context =  _storageDbContextFactory.Create())
            {
                CategoryDto categoryDto = new CategoryDto()
                {
                    CategoryDtoID = categoryID,
                };

                context.CategoryDtos.Remove(categoryDto);
                context.SaveChangesAsync();
            }
        }
    }
}
