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
    public class CreateCategory: ICreateCategory
    {
        private readonly StorageDbContextFactory _storageDbContextFactory;

        public CreateCategory(StorageDbContextFactory storageDbContextFactory)
        {
            _storageDbContextFactory = storageDbContextFactory;
        }

        public async Task Execute(Category category)
        {
            using (StorageDbContext context = _storageDbContextFactory.Create())
            {
                CategoryDto categoryDto = new CategoryDto()
                {
                    CategoryDtoID = category.categoryID,
                    categoryName = category.categoryName,
                    createDate = category.createDate,
                    modifyDate = category.modifyDate,
                    userID = category.userID,
                };

                context.CategoryDtos.Add(categoryDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
