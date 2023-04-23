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
    public class UpdateCategory : IUpdateCategory
    {
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public UpdateCategory(StorageDbContextFactory storageDbContextFactory)
        {
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async Task Execute(Category category)
        {
            using (StorageDbContext context =  _storageDbContextFactory.Create())
            {
                CategoryDto categoryDto = new CategoryDto()
                {
                    CategoryDtoID = category.categoryID,
                    categoryName = category.categoryName,
                    userID = category.userID,
                    modifyDate = category.modifyDate,
                    createDate = category.createDate,
                };

                context.CategoryDtos.Update(categoryDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
